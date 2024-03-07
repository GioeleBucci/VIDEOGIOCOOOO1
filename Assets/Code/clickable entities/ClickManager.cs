using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

/**
 This class models an object that keeps track of the last selected GameObject. 
 When a second click occurs, it checks wether a suitable position was clicked
 and creates a vector that the selected entity tries to follow.
 */
public class ClickManager : MonoBehaviour
{
    // for now movement vector should not be used, since the click manager might have to deal with
    // different entities.
    [SerializeField] Vector2 _movementVector;
    [SerializeField] IClickable selectedEntity;
    [SerializeField] bool isAnEntitySelected;
    [SerializeField] Transform clickedEntityTransform;
    public Vector2 MovementVector { get { return this._movementVector; } }

    public IClickable GetSelectedEnetity() => this.selectedEntity;

    /// <summary>
    /// Give a reference to this manager to IClickables that need to be handled,
    /// by dragging this Manager into their SerializedField in the Unity Editor (see
    /// <see cref="ClickableEntityBehaviour"/> for more details about usage in GameObjects).
    /// </summary>
    /// <param name="clickedEntity">The clicked entity; its data are saved in the field
    /// of this object. If the clicked entity was already selected, it is now deselected.</param>
    public void Notify(IClickable clickedEntity)
    {
        // if the player clicks twice on the same entity, it should be deselected
        if (this.isAnEntitySelected && this.selectedEntity.Equals(clickedEntity))
        {
            Debug.Log("Deselected entity: " + clickedEntity);
            this.Deselect().OnDeselection();
            return;
        } // if the player clicks on an entity while another one is already selected:
        else if (this.isAnEntitySelected /* and the newly selected entity is not a position on the world map...*/)
        {
            this.Deselect().OnDeselection();
        }
        Debug.Log("Clicked at position: " + clickedEntity.GetTransform().position + ", clickedEntity.Type = " + clickedEntity.GetType());
        this.selectedEntity = clickedEntity;
        this.isAnEntitySelected = true;
        this.clickedEntityTransform = clickedEntity.GetTransform();
        clickedEntity.OnSelection();
    }

    private IClickable Deselect()
    {
        if (this.isAnEntitySelected)
        {
            this.isAnEntitySelected = false;
        }
        IClickable entity = this.selectedEntity;
        this.selectedEntity = null;
        return entity;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.isAnEntitySelected = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
