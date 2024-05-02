using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
