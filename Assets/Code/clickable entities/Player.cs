using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IClickable
{
    public bool selected;
    public void OnClick()
    {
        this.selected = !this.selected;
        if (this.selected)
        {
            // If the player is selected, make it available to the component
            // responsible of his movement
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
        
    }
}
