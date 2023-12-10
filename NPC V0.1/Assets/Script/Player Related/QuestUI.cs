using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public Text questText;

    private void OnEnable()
    {
        // Subscribe to the onItemChangedCallback
        Inventory.Instance.onItemChangedCallback += UpdateQuestUI;
    }

    private void OnDisable()
    {
        // Unsubscribe when the object is disabled or destroyed
        Inventory.Instance.onItemChangedCallback -= UpdateQuestUI;
    }

    private void UpdateQuestUI()
    {
        // Check if the quest is completed
/*        if (Inventory.Instance.BatteriesCollected == Inventory.Instance.batteriesNeeded)
        {
            // Update the UI text with strikethrough effect
            questText.text = "<s>Quest: Collect 5 Batteries</s>";
        }*/
    }
}
