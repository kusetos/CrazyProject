using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelObject : MonoBehaviour
{
    public LevelObjectType ObjectType;
}
public enum LevelObjectType
{
    TARGET = 0,
    SIMPLE_BLOCK = 1
}
