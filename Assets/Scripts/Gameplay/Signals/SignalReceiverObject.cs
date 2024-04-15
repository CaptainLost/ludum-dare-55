using System;
using System.Collections.Generic;
using UnityEngine;

public class SignalReceiverObject : SignalObject
{
    [SerializeField]
    private List<SignalTagSO> m_signalTags;

    public Action<bool> OnSignalChanged;

    public bool IsActive { get; private set; }

    protected override void OnObjectEnterAnyCell(ObjectEnterCellEvent cellEnterEvent)
    {
        if (cellEnterEvent.CellPosition == GridObjectData.GridPosition)
        {
            if (!ValidateSingalObject(cellEnterEvent.GridObject))
                return;

            SetSignal(true);
        }
    }

    protected override void OnObjectLeaveAnyCell(ObjectLeaveCellEvent cellLeaveEvent)
    {
        if (cellLeaveEvent.CellPosition == GridObjectData.GridPosition)
        {
            if (!ValidateSingalObject(cellLeaveEvent.GridObject))
                return;

            SetSignal(false);
        }
    }

    public virtual void SetSignal(bool active)
    {
        if (IsActive == active)
            return;

        IsActive = active;

        OnSignalChanged?.Invoke(IsActive);
    }

    private bool ValidateSingalObject(GridObject gridObject)
    {
        SignalGridObject signalObject = gridObject as SignalGridObject;

        if (signalObject == null)
            return false;

        foreach (SignalTagSO signalTag in m_signalTags)
        {
            if (!signalObject.SignalTags.Contains(signalTag))
            {
                return false;
            }
        }

        return true;
    }
}
