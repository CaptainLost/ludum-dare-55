using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class GridDatabase
{
    [field: SerializeField]
    public List<GridObject> GridObjects { get; private set; } = new List<GridObject>(); // Should be hash set, but it isn't serializable :c

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
    [SerializeField]
    private Grid m_grid;
    [SerializeField]
    private Tilemap m_collisionTilemap;
    [field: SerializeField]
    public GridDatabase PlayerDatabase { get; private set; } = new();

    public GridDatabase ObjectDatabase { get; private set; } = new();

    public void RegisterObject(GridObject gridObject)
    {
        ObjectDatabase.RegisterObject(gridObject);
    }

    public void UnregisterObject(GridObject gridObject)
    {
        ObjectDatabase.UnregisterObject(gridObject);
    }

    public GridObject GetObjectAtCell(Vector3Int gridPosition) // To rework
    {
        foreach (GridObject gridObject in ObjectDatabase.GridObjects)
        {
            if (gridObject.GridObjectData.GridPosition == gridPosition)
                return gridObject;
        }

        return null;
    }

    public bool HasStaticCollision(Vector3Int gridPosition)
    {
        if (m_collisionTilemap.HasTile(gridPosition))
            return true;

        return false;
    }

    public Vector3 CellToWorld(Vector3Int gridPosition)
    {
        return m_grid.GetCellCenterWorld(gridPosition);
    }

    public Vector3Int WorldToCell(Vector3 worldPosition)
    {
        return m_grid.WorldToCell(worldPosition);
    }
}
