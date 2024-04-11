using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine;

public static class Mover
{
    public static void MoveEntity(IClickable entity, Vector2 targetPosition, float velocity)
    {
        entity.SetPosition(Vector2.MoveTowards(entity.GetPosition(),
                                               targetPosition,
                                               velocity * Time.deltaTime));
    }
}