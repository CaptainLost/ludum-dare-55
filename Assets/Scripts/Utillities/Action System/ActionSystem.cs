using System.Collections.Generic;
using UnityEngine;

namespace CptLost.ActionSystem
{
    public class ActionSystem : MonoBehaviour
    {
        public IAction CurrentAction { get; private set; }

        protected Queue<IAction> _actionQueue = new Queue<IAction>();

        protected virtual void Update()
        {
            if (CurrentAction == null || CurrentAction.ShouldActionStop())
            {
                SetNextActionFromQueue();
            }

            CurrentAction?.OnActionUpdate();
        }

        public virtual bool IsActionActive()
        {
            return CurrentAction != null;
        }

        public virtual void SetCurrentAction(IAction action)
        {
            CurrentAction?.OnActionStop();
            CurrentAction = action;
            CurrentAction?.OnActionStart();
        }

        public virtual void AddActionToQueue(IAction action)
        {
            _actionQueue.Enqueue(action);
        }

        public virtual void ClearActionQueue()
        {
            _actionQueue.Clear();
        }

        protected virtual void SetNextActionFromQueue()
        {
            IAction nextAction = null;

            if (_actionQueue.Count > 0)
            {
                nextAction = _actionQueue.Dequeue();
            }

            SetCurrentAction(nextAction);
        }
    }
}
