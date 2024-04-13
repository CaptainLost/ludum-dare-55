using UnityEngine;

public class MoveAction : GridAction
{
    public bool IsFinished { get; private set; }

    private GridManager m_gridManager;

    private Vector3Int m_cellTargetPosition;
    private Vector3 m_worldTargetPosition;
    private float m_moveSpeed;

    private bool m_isActionValid;

    public MoveAction(GridObject owningObject, Vector3Int gridTargetPosition, float moveSpeed)
        : base(owningObject)
    {
        m_gridManager = m_owningObject.GridObjectData.GridManager;

        m_cellTargetPosition = gridTargetPosition;
        m_worldTargetPosition = m_gridManager.CellToWorld(m_cellTargetPosition);
        m_moveSpeed = moveSpeed;
    }

    public override void OnActionStart()
    {
        m_isActionValid = IsMoveValid();
    }

    public override void OnActionStop()
    {
        
    }

    public override void OnActionUpdate()
    {
        Vector3 worldNewPosition = Vector3.MoveTowards(m_owningObject.transform.position, m_worldTargetPosition, m_moveSpeed * Time.deltaTime);

        Vector3Int cellNewPosition = m_gridManager.WorldToCell(worldNewPosition);

        m_owningObject.transform.position = worldNewPosition;
        m_owningObject.GridObjectData.GridPosition = cellNewPosition;
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
        if (m_owningObject.HasFlag(GridObjectFlags.Static_Collision) && m_gridManager.HasStaticCollision(m_cellTargetPosition))
            return false;

        return true;
    }
}
