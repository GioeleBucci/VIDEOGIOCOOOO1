using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IClickable
{
    public bool selected;
    /*
     private FiniteStateMachine ... -> a state machine with two states to begin with: "Moving" and "Still"
     */

    public void OnPointerClick(PointerEventData eventData)
    {
        this.selected = !this.selected;
        if (this.selected)
        {
            // If the player is selected, make it available to the component
            // responsible of his movement

            /* SelectionManager.notify("this object was clicked") ... */
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.selected = false;
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
