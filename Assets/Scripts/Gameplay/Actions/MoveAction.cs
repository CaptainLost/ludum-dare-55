using CptLost.EventBus;
using UnityEngine;

public class MoveAction : GridAction
{
    public bool IsFinished { get; private set; }

    protected Vector3Int m_cellTargetPosition;
    protected Vector3 m_worldTargetPosition;
    protected float m_moveSpeed;

    protected bool m_isActionValid;

    public MoveAction(GridObject owningObject, GridManager gridManager, Vector3Int gridTargetPosition, float moveSpeed)
        : base(owningObject, gridManager)
    {
        m_cellTargetPosition = gridTargetPosition;
        m_worldTargetPosition = m_gridManager.CellToWorld(m_cellTargetPosition);
        m_moveSpeed = moveSpeed;
    }

    public override void OnActionStart()
    {
        m_isActionValid = IsMoveValid();

        if (m_isActionValid)
        {
            EventBus<ObjectLeaveCellEvent>.Invoke(new ObjectLeaveCellEvent(m_owningObject.GridObjectData.GridPosition, m_owningObject));

            m_owningObject.GridObjectData.GridPosition = m_cellTargetPosition;
        }
    }

    public override void OnActionStop()
    {
        if (!m_isActionValid)
            return;

        EventBus<ObjectEnterCellEvent>.Invoke(new ObjectEnterCellEvent(m_cellTargetPosition, m_owningObject));
    }

    public override void OnActionUpdate()
    {
        Vector3 worldNewPosition = Vector3.MoveTowards(m_owningObject.transform.position, m_worldTargetPosition, m_moveSpeed * Time.deltaTime);

        m_owningObject.transform.position = worldNewPosition;
    }

    public override bool ShouldActionStop()
    {
        return !m_isActionValid || (m_owningObject.transform.position == m_worldTargetPosition);
    }

    public override void UndoAction()
    {
        
    }

    protected virtual bool IsMoveValid()
    {
        if (m_owningObject.HasFlag(EGridObjectFlags.Static_Collision) && m_gridManager.HasStaticCollision(m_cellTargetPosition))
            return false;

        if (m_owningObject.HasFlag(EGridObjectFlags.Dynamic_Collision))
        {
            foreach (GridObject gridObject in m_gridManager.ObjectDatabase.GridObjects) // Reword to not loop throught all objects
            {
                if (m_owningObject == gridObject || gridObject.GridObjectData.GridPosition != m_cellTargetPosition)
                    continue;

                if (gridObject.HasFlag(EGridObjectFlags.Dynamic_Collision))
                    return false;
            }
        }

        return true;
    }
}
