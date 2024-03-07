using UnityEngine;
using UnityEngine.EventSystems;

/*
 An interface modelling an object that can be clicked. Players and suitable
terrain tiles should implement this interface.
 */
public interface IClickable
{
    /// <summary>
    /// Get the <see cref="Transform"/> of this clickable entity.
    /// </summary>
    /// <returns>The <see cref="Transform"/> of this IClickable.</returns>
    Transform GetTransform();
    /// <summary>
    /// Entity behaviour on selection, called by the <see cref="ClickManager"/>.
    /// </summary>
    void OnSelection();
    /// <summary>
    /// Entity behaviour on deselection, called by the <see cref="ClickManager"/>.
    /// </summary>
    void OnDeselection();
}

