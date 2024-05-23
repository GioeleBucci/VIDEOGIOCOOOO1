using UnityEngine;

/// <summary>
/// The context menu is the menu that is displayed when right-clicking on
/// some entities.
/// </summary>
public class ContextMenuBehaviour : MonoBehaviour
{
    public void ActivateContextMenu(Vector2 c)
    {
        this.gameObject.transform.position = c;
        this.gameObject.SetActive(true);
    }

    public void DeactivateContextMenu()
    {
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.DeactivateContextMenu();
    }
}
