using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/**
 This class models an object that keeps track of the last selected GameObject. 
 When a second click occurs, it checks wether a suitable position was clicked
 and creates a vector that the selected entity tries to follow.
 */
public class ClickManager : MonoBehaviour
{
    // for now movement vector should not be used, since the click manager might have to deal with
    // different entities.
    [SerializeField] private Vector2 _movementVector;
    [SerializeField] private IClickable selectedEntity;
    [SerializeField] private bool isAnEntitySelected;
    [SerializeField] private Stack<IClickable> clickedEntitiesStack;

    // UI that appears when right-clicking some entities
    [SerializeField] private ContextMenuUI contextMenuUI;

    public Vector2 MovementVector { get { return this._movementVector; } }

    public IClickable GetSelectedEntity() => this.selectedEntity;

    /// <summary>
    /// Give a reference to this manager to IClickables that need to be handled,
    /// by dragging this Manager into their SerializedField in the Unity Editor (see
    /// <see cref="ClickableEntityBehaviour"/> for more details about usage in GameObjects).
    /// </summary>
    /// <param name="clickedEntity">The clicked entity; its data are saved in the field
    /// of this object. If the clicked entity was already selected, it is now deselected.</param>
    public void Notify(IClickable clickedEntity)
    {
        this.clickedEntitiesStack.Push(clickedEntity);
        if (this.clickedEntitiesStack.Count == 2)
        {
            IClickable firstEntity = this.clickedEntitiesStack.Pop();
            IClickable secondEntity = this.clickedEntitiesStack.Pop();
            this.ManageClickedEntities(firstEntity, secondEntity);
        }
        else
        {
            this.Select(clickedEntity);
            Assert.IsTrue(this.clickedEntitiesStack.Count < 2);
        }

    }

    private void ManageClickedEntities(IClickable first, IClickable second)
    {
        if (first.Equals(second))
        {
            this.Deselect().OnDeselection();
            return;
        }
        else if (first.GetType().Equals("Position") && second.GetType().Equals("Guard"))
        {
            // manage movement
            second.Move(first.GetPosition());
        }
        else
        {
            Deselect();
        }
    }

    private void Select(IClickable clickedEntity)
    {
        Debug.Log("Clicked at position: " + clickedEntity.GetPosition() + ", clickedEntity.Type = " + clickedEntity.GetType());
        this.selectedEntity = clickedEntity;
        this.isAnEntitySelected = true;
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

    /// <summary>
    /// Gives access to the context menu UI to entities that need it.
    /// </summary>
    /// <returns>The context menu UI.</returns>
    public ContextMenuUI GetContextMenuUI() => this.contextMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        this.isAnEntitySelected = false;
        this.clickedEntitiesStack = new();
    }
}
