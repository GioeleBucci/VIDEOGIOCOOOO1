using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExtendedClickableEntityBehaviour : ClickableEntityBehaviour
{
    /// <summary>
    /// OnMouseDown() is only called when the left button is clicked... so
    /// to detect right clicks I need to use an alternative method.
    /// </summary>

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            this.GetClickManager().HandleContextMenu();
        }
    }
}
