using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Followed video at
/// https://www.youtube.com/watch?v=l0emsAHIBjU
/// </summary>
public class TestInputManager : MonoBehaviour
{

    public Vector2 GetSelectedMapPosition()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Mouse is over this position: " + mousePos + " in the Tilemap");
        return mousePos;
    }

    public void Update()
    {
        this.GetSelectedMapPosition();
    }
}
