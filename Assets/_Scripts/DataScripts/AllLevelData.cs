using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new DataWithLevels", menuName = "Data With Levels", order = 51)]
public class AllLevelData : ScriptableObject
{
    [SerializeField] List<ScriptableLevel> _levelsData;
    public List<ScriptableLevel> LevelsData => _levelsData;
}
