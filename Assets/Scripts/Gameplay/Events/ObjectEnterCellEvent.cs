using CptLost.EventBus;
using UnityEngine;

public struct ObjectEnterCellEvent : IBusEvent
{
    public Vector3Int CellPosition;
    public GridObject GridObject;

    public ObjectEnterCellEvent(Vector3Int cellPosition, GridObject gridObject)
    {
        CellPosition = cellPosition;
        GridObject = gridObject;
    }
}
