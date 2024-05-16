using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that must not be attached to any GameObject.
/// It's simply a record IClickable modelling a clicked position.
/// This class is mutable.
/// </summary>
public class ClickablePosition : IClickable
{
    private Vector2 position;
    public ClickablePosition(Vector2 position) => this.position = position;

    public Vector2 GetPosition() => this.position;

    public void Move(Vector2 position) { }

    public void OnDeselection()
    {
    }

    public void OnSelection()
    {
    }

    public void SetPosition(Vector2 position) => this.position = position;

    string IClickable.GetType() => "Position";
}
