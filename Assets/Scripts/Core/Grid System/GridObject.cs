using CptLost.ActionSystem;
using System;
using UnityEngine;
using Zenject;

[Serializable]
public class GridObjectData
{
    public Vector3Int GridPosition;
}

public class GridObject : MonoBehaviour
{
    [SerializeField]
    private ActionSystem m_actionSystem;

    public EGridObjectFlags ObjectFlags;

    public GridObjectData GridObjectData { get; private set; }

    [Inject]
    protected GridManager m_gridManager;

    protected virtual void OnEnable()
    {
        m_gridManager.RegisterObject(this);
    }

    protected virtual void OnDisable()
    {
        m_gridManager.UnregisterObject(this);
    }

    protected virtual void Awake()
    {
        GridObjectData = new GridObjectData();

        SnapToCurrentCellPosition();
    }

    public virtual void Move(Vector3Int newPosition)
    {
        GridObjectData.GridPosition = newPosition;
    }

    public bool RequestAction(GridAction gridAction)
    {
        if (HasActionActive())
            return false;

        m_actionSystem.SetCurrentAction(gridAction);

        return true;
    }

    public bool HasActionActive()
    {
        return m_actionSystem.IsActionActive();
    }

    public bool HasFlag(EGridObjectFlags flag)
    {
        return ObjectFlags.HasFlag(flag);
    }

    private void SnapToCurrentCellPosition()
    {
        GridObjectData.GridPosition = m_gridManager.WorldToCell(transform.position);
        transform.position = m_gridManager.CellToWorld(GridObjectData.GridPosition);
    }
}
