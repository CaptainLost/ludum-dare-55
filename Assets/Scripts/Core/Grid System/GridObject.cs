using CptLost.ActionSystem;
using UnityEngine;
using Zenject;

public class GridObjectData
{
    public Vector3Int GridPosition;
}

public abstract class GridObject : MonoBehaviour
{
    [SerializeField]
    private ActionSystem m_actionSystem;

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

    public void RequesAction(GridAction gridAction)
    {
        if (m_actionSystem.IsActionActive())
            return;

        m_actionSystem.SetCurrentAction(gridAction);
    }
}
