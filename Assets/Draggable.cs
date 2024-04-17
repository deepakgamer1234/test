using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    GameObject placeholder = null;

    public bool isSelected = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("coming here...");
        if (!isSelected)
        {
            SelectCard();
        }
        else
        {
            DeselectCard();
        }
    }

    void SelectCard()
    {
        isSelected = true;
        Debug.Log("selected........");
        // Change the visual state of the card to indicate it's selected

        GetComponent<Image>().color = Color.gray; // Changed from Renderer to Image
        Vector3 newPosition = transform.position;
        newPosition.y += 10; // Adjust this value to change the amount of upward movement
        transform.position = newPosition;
    }

    void DeselectCard()
    {
        isSelected = false;
        // Change the visual state of the card to indicate it's deselected
        GetComponent<Image>().color = Color.white; // Changed from Renderer to Image
        Vector3 newPosition = transform.position;
        newPosition.y -= 10; // Adjust this value to change the amount of upward movement
        transform.position = newPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        GetComponent<CanvasGroup>().alpha = 0.5f;
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //  DeselectCard();

    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log ("OnDrag");

        //GetComponent<CanvasGroup>().alpha = 0.5f;

        this.transform.position = eventData.position;
        DeselectCard();
        //if(placeholder.transform.parent != placeholderParent)
        //	placeholder.transform.SetParent(placeholderParent);

        int newSiblingIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {

                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        GetComponent<CanvasGroup>().alpha = 1f;
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeholder);
        OnDropCompleted(this.gameObject);

        int selectedCount = 0;
        foreach (Transform child in parentToReturnTo)
        {
            Draggable draggable = child.GetComponent<Draggable>();
            if (draggable != null && draggable.isSelected)
            {
                selectedCount++;
            }
        }
        if (selectedCount > 2)
        {
            foreach (Transform child in parentToReturnTo)
            {
                Draggable draggable = child.GetComponent<Draggable>();
                if (draggable != null && draggable.isSelected && draggable != this)
                {
                    draggable.isSelected = false;
                    draggable.GetComponent<Image>().color = Color.white;
                }
            }
        }
    }

    public void OnDropCompleted(GameObject card)
    {
        Draggable draggable = card.GetComponent<Draggable>();
        if (draggable != null)
        {
            draggable.isSelected = false;
        }
        GetComponent<Image>().color = Color.white;
    }
}
