using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GridObjectData
{
    public Vector2Int GridPosition;
}

public abstract class GridObject : MonoBehaviour
{
    public GridObjectData GridObjectData = new();

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
}
