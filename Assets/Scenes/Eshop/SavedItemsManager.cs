using UnityEngine;

public class SavedItemsManager : MonoBehaviour
{
    public GameObject savedItemPrefab; // Example prefab for saved item
    public Transform savedItemsParent; // Parent transform where saved items are listed

    // Function to delete a saved item
    public void DeleteSavedItem(GameObject savedItem)
    {
        // Perform deletion logic (remove from list, destroy GameObject, etc.)
        Destroy(savedItem);

        // Call HideDescription() on ButtonHoverText component to hide description if it's visible
        ButtonHoverText hoverText = savedItem.GetComponent<ButtonHoverText>();
        if (hoverText != null)
        {
            hoverText.HideDescription();
        }
    }
}

