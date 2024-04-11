using UnityEngine;
using UnityEngine.EventSystems;

/*
 An interface modelling an object that can be clicked. Players and suitable
terrain tiles should implement this interface.
 */
public interface IClickable
{
    /// <summary>
    /// Entity behaviour on selection, called by the <see cref="ClickManager"/>.
    /// </summary>
    void OnSelection();
    /// <summary>
    /// Entity behaviour on deselection, called by the <see cref="ClickManager"/>.
    /// </summary>
    void OnDeselection();

    string GetType();

    Vector2 GetPosition();

    void SetPosition(Vector2 position);

    void Move(Vector2 position);

}

