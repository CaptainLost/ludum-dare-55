namespace CptLost.ActionSystem
{
    public interface IAction
    {
        void OnActionStart();
        void OnActionStop();
        void OnActionUpdate();
        bool ShouldActionStop();
    }
}