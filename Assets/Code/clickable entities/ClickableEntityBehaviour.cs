using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/* TODO: piangere
 Ecco un link con alcune delle idee su quali potrebbero essere delle brutte pratiche
in Unity: https://www.reddit.com/r/Unity3D/comments/9yg57s/what_are_some_bad_practices_to_avoid_when_using/
 */
public class ClickableEntityBehaviour : MonoBehaviour, IClickable
{
    /* A reference to the ClickManager, to be dragged and dropped in the Unity Editor: */
    [SerializeField] ClickManager clickManager;
    private Color originalColor; //this is needed because there is no easy way to deep copy a Color
    public Transform GetTransform() => this.transform;

    /// <summary>
    /// I finally understood how to make clickable objects and what went wrong before:
    /// 
    /// - All MonoBehaviour objects have an "OnMouseDown()" method. This is available only if the
    /// object has a "Collider" attached from the editor as a component.
    /// - OnMouseDown() acts as a Raycast, which detects the first object it hits; in our case, it
    /// was the sight radius of the guard and not the guard itself, this is why I couldn't click the guard.
    /// - However, if an object in the hierarchy has a "RigidBody" component, the Raycast will ignore other
    /// children objects and only consider the one with the "RigidBody" component.
    /// 
    /// Other interesting matters:
    /// - scripts that don't need a GameObject can inherit from ScriptableObject.  
    /// </summary>
    public void OnMouseDown()
    {
        Debug.Log("At least I was clicked");
        this.clickManager.Notify(this);
    }

    public void OnSelection()
    {
        // change color if this entity was selected now
        this.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public void OnDeselection()
    {
        this.GetComponent<SpriteRenderer>().color = this.CopyColor(originalColor);
        Debug.Log("Called OnDeselect in object");        
    }

    private Color CopyColor(Color oldColor)
    {
        return new Color(oldColor.r, oldColor.g, oldColor.b, oldColor.a);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.originalColor = this.CopyColor(this.GetComponent<SpriteRenderer>().color);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
