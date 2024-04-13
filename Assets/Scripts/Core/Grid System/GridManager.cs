using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GridDatabase
{
    [field: SerializeField]
    public HashSet<GridObject> GridObjects { get; private set; } = new HashSet<GridObject>();

    public void RegisterObject(GridObject gridObject)
    {
        GridObjects.Add(gridObject);
    }

    public void UnregisterObject(GridObject gridObject)
    {
        GridObjects.Remove(gridObject);
    }

    public void LoopThroughtAllObjects(Action<GridObject> actionPerObject)
    {
        foreach (GridObject gridObject in GridObjects)
        {
            actionPerObject(gridObject);
        }
    }
}

public class GridManager : MonoBehaviour
{
    [SerializeField] private Grid m_grid;
    [field: SerializeField]
    public GridDatabase PlayerDatabase { get; private set; } = new();

    public GridDatabase GridDatabase { get; private set; } = new();

    public void RegisterObject(GridObject gridObject)
    {
        GridDatabase.RegisterObject(gridObject);
    }

    public void UnregisterObject(GridObject gridObject)
    {
        GridDatabase.UnregisterObject(gridObject);
    }

    public Vector3 GridCellToWorld(Vector3Int gridPosition)
    {
        return m_grid.GetCellCenterWorld(gridPosition);
    }
}
