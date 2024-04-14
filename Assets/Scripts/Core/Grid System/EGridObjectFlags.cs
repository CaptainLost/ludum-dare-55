using System;

[Flags]
public enum EGridObjectFlags
{
    None,
    Static_Collision = 1 << 0,
    Dynamic_Collision = 1 << 1,
    Pushable = 1 << 2,
}
