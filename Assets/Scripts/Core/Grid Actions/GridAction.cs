using CptLost.ActionSystem;

public abstract class GridAction : IAction
{
    protected GridObject m_owningObject;

    public GridAction(GridObject owningObject)
    {
        m_owningObject = owningObject;
    }

    public abstract void OnActionStart();
    public abstract void OnActionStop();
    public abstract void OnActionUpdate();
    public abstract bool ShouldActionStop();
    public abstract void UndoAction();
}
