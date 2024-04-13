using CptLost.ActionSystem;
using UnityEngine;
using Zenject;

public class GridObjectData
{
    public GridObjectData(GridManager gridManager)
    {
        GridManager = gridManager;
    }

    public GridManager GridManager { get; private set; }
    public Vector3Int GridPosition;
}

public abstract class GridObject : MonoBehaviour
{
    [SerializeField]
    private ActionSystem m_actionSystem;
    [SerializeField]
    private GridObjectFlags m_objectFlags;

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
        GridObjectData = new GridObjectData(m_gridManager);

        transform.position = m_gridManager.CellToWorld(GridObjectData.GridPosition);
    }

    public void RequestAction(GridAction gridAction)
    {
        if (m_actionSystem.IsActionActive())
            return;

        m_actionSystem.SetCurrentAction(gridAction);
    }

    public bool HasFlag(GridObjectFlags flag)
    {
        return m_objectFlags.HasFlag(flag);
    }
}
