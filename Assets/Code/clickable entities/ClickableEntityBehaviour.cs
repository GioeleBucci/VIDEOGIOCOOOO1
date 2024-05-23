using UnityEngine;

/// <summary>
/// This behaviour is used by the Guards, that can move to a given target, stored
/// in the field target.
/// </summary>
public class ClickableEntityBehaviour : MonoBehaviour, IClickable
{
    /* A reference to the ClickManager, to be dragged and dropped in the Unity Editor: */
    [SerializeField] private ClickManager clickManager;
    private Color originalColor; //this is needed because there is no easy way to deep copy a Color 
    //public Transform GetTransform() => this.transform;
    private Vector2? target;
    [SerializeField]
    private float velocity = 5f;
    public Vector2 Target { set { target = value; } }

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
 
    /// I just found out thanks to FraDente that in C# if you want methods with default behaviour that can
    /// be overridden with the 'override' keyword, you need to declare them as 'virtual'
    public virtual void OnMouseDown()
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
        this.target = null;
        this.originalColor = this.CopyColor(this.GetComponent<SpriteRenderer>().color);
    }

    // Update is called once per frame
    void Update()
    {
        if (target.HasValue)
        {
            Debug.Log("haikfhah");
            this.transform.position = Vector2.MoveTowards(this.transform.position, target.Value, velocity * Time.deltaTime);
            if (Vector2.Distance(this.transform.position, target.Value) < .05f)
            {
                target = null;
            }
        }
    }

    string IClickable.GetType() => this.tag;

    public Vector2 GetPosition() => this.transform.position;

    public void SetPosition(Vector2 position) => this.transform.position = position;

    public void Move(Vector2 position) {
        this.target = position;
        Debug.Log("Target value = " + this.target);
    }

    protected ClickManager GetClickManager() => this.clickManager;
}
