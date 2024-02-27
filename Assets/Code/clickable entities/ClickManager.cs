using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

/**
 This class models an object that keeps track of the last selected GameObject. 
 When a second click occurs, it checks wether a suitable position was clicked
 and creates a vector that the selected entity tries to follow.
 */
public class ClickManager : MonoBehaviour, IClickListener
{
    [SerializeField] private Vector2 _movementVector;
    [SerializeField] private IClickable selectedEntity;
    [SerializeField] private bool isAnEntitySelected = false;
    [SerializeField] private Transform clickedEntityTransform;
    public Vector2 MovementVector { get { return this._movementVector; } }

    public void Notify(IClickable clickedEntity, PointerEventData clickEvent)
    {
        Debug.Log("Clicked at position: " + clickEvent.position + ", clickedEntity.Type = " + clickedEntity.GetType());
        if (!this.isAnEntitySelected)
        {
            this.selectedEntity = clickedEntity;
            this.isAnEntitySelected = true;
            this.clickedEntityTransform = clickedEntity.GetTransform();
        }
        else
        {
            this._movementVector = new Vector2(clickEvent.position.x - this.clickedEntityTransform.position.x,
                                              clickEvent.position.y - this.clickedEntityTransform.position.y);
            Debug.Log("Entity: " + clickedEntity + "selected, moving to: " + _movementVector);
            this.isAnEntitySelected = false;
            this.selectedEntity = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
