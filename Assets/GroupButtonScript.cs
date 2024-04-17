
using UnityEngine;
using UnityEngine.UI;

public class GroupButtonScript : MonoBehaviour
{
    public Hand hand;
    public Button groupButton; // Reference to the Group button
    public GameObject tableTop; // Reference to the TableTop GameObject in your scene

    public void OnGroupButtonClick()
    {
        foreach (GameObject card in hand.selectedCards)
        {
            card.transform.SetParent(tableTop.transform);
            Draggable draggable = card.GetComponent<Draggable>();
            if (draggable != null)
            {
                draggable.isSelected = false;
            }
            Image image = card.GetComponent<Image>();
            if (image != null)
            {
                image.color = Color.white;
            }
        }
        hand.selectedCards.Clear(); // Clear the selected cards list

        // Disable the Group button after grouping the cards
        groupButton.interactable = false;
    }
}
