using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalReceiverObject : SignalObject
{
    protected override void OnObjectEnterAnyCell(ObjectEnterCellEvent cellEnterEvent)
    {
        if (cellEnterEvent.CellPosition == GridObjectData.GridPosition)
        {
            Debug.Log("Enter");
        }
    }
}
