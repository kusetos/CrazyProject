using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelObject : MonoBehaviour
{
    [SerializeField] private LevelObjectType _type;
    public LevelObjectType ObjectType => _type;
}
