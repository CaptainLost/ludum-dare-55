using CptLost.EventBus;
using UnityEngine;

public struct ObjectLeaveCellEvent : IBusEvent
{
    public Vector3Int CellPosition;
    public GridObject GridObject;

    public ObjectLeaveCellEvent(Vector3Int cellPosition, GridObject gridObject)
    {
        CellPosition = cellPosition;
        GridObject = gridObject;
    }
}
