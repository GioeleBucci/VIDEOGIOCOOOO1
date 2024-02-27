using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public interface IClickListener
{
    /* Documentation about ClickEvents:
       https://docs.unity3d.com/Manual/UIE-Click-Events.html#:~:text=A%20ClickEvent%20occurs%20when%20the,event%20on%20the%20same%20VisualElement.
     */
    public void Notify(IClickable clickedEntity, PointerEventData clickEvent);

}
