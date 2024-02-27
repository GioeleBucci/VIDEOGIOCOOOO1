using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/* TODO: piangere
 Ecco un link con alcune delle idee su quali potrebbero essere delle brutte pratiche
in Unity: https://www.reddit.com/r/Unity3D/comments/9yg57s/what_are_some_bad_practices_to_avoid_when_using/
 */
public class Player : MonoBehaviour, IClickable
{
    [SerializeField] private List<IClickListener> clickListeners;
    public Transform GetTransform() => this.transform;

    /*
private FiniteStateMachine ... -> a state machine with two states to begin with: "Moving" and "Still"
*/
    public Player()
    {
        this.clickListeners = new List<IClickListener>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (var listener in this.clickListeners) 
        {
            listener.Notify(this, eventData);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // I want to add the Click Manager as a listener :'(
        //this.clickListeners.Add();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         if (this.StateMachine.GetState().Equals(Moving)) {
            follow path to target
        }
         */
    }
}
