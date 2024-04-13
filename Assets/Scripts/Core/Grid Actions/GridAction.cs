using CptLost.ActionSystem;

public abstract class GridAction : IAction
{
    protected GridObject m_owningObject;
    protected GridManager m_gridManager;

    public GridAction(GridObject owningObject, GridManager gridManager)
    {
        m_owningObject = owningObject;
        m_gridManager = gridManager;
    }

    public abstract void OnActionStart();
    public abstract void OnActionStop();
    public abstract void OnActionUpdate();
    public abstract bool ShouldActionStop();
    public abstract void UndoAction();
}
