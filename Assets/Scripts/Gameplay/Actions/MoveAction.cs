using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : GridAction
{
    public bool IsFinished { get; private set; }

    public MoveAction(GridObject owningObject, Vector3 worldTargetPosition)
        : base(owningObject)
    {

    }

    public override void OnActionStart()
    {
        
    }

    public override void OnActionStop()
    {
        
    }

    public override void OnActionUpdate()
    {
        
    }

    public override bool ShouldActionStop()
    {
        return false;
    }

    public override void Undo()
    {
        
    }
}
