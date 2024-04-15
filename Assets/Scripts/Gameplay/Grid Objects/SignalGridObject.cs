using System.Collections.Generic;
using UnityEngine;

public class SignalGridObject : GridObject
{
    [field: SerializeField]
    public List<SignalTagSO> SignalTags { get; private set; }
}
