using UnityEngine;

public class ContextMenuUI : MonoBehaviour
{
    // UI ELEMENTS
    [SerializeField] private bool isContextMenuActivated = false;
    [SerializeField] private ContextMenuBehaviour contextMenu;

    // UI
    public void HandleContextMenu(Vector2 clickedPosition)
    {
        if (!this.isContextMenuActivated)
        {
            this.ActivateContextMenu(clickedPosition);
        }
        else
        {
            this.DeactivateContextMenu();
        }
    }

    // UI
    private void ActivateContextMenu(Vector2 c)
    {
        Debug.Log("Activating context menu in Click Manager");
        this.isContextMenuActivated = true;
        this.contextMenu.ActivateContextMenu(c);
    }

    // UI
    private void DeactivateContextMenu()
    {
        Debug.Log("Deactivating context menu in Click Manager");
        this.isContextMenuActivated = false;
        this.contextMenu.DeactivateContextMenu();
    }
}
