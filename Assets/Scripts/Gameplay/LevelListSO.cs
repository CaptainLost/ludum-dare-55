using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level List", menuName = "Level List")]
public class LevelListSO : ScriptableObject
{
    [field: SerializeField]
    public List<SceneField> Levels { get; private set; }
}
