using CptLost.EventBus;
using UnityEngine;

public struct PlayerMoveEvent : IBusEvent
{
    public Vector3Int CellTargetPosition { get; private set; }

    public PlayerMoveEvent(Vector3Int cellTargetPosition)
    {
        CellTargetPosition = cellTargetPosition;
    }
}
