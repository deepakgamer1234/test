
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{

    public List<GameObject> selectedCards = new List<GameObject>();
    public HorizontalLayoutGroup handLayoutGroup;
    public Button groupButton; // Reference to the Group button

   

    void Update()
    {
        foreach (GameObject card in GameObject.FindGameObjectsWithTag("Card"))
        {
            Draggable draggable = card.GetComponent<Draggable>();
            if (draggable.isSelected && !selectedCards.Contains(card))
            {
                selectedCards.Add(card);
            }
            else if (!draggable.isSelected && selectedCards.Contains(card))
            {
                selectedCards.Remove(card);
            }
        }

        // Enable or disable the Group button based on the count of selected cards
        groupButton.interactable = selectedCards.Count > 1;

    }

    public void GroupSelectedCards()
    {
        foreach (GameObject card in selectedCards)
        {
            // Add the logic to group the selected cards here
        }
    }
}
