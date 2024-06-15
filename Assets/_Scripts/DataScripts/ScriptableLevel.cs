using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//[CreateAssetMenu(fileName = "LevelData", menuName = "Level Data", order = 51)]
public class ScriptableLevel : ScriptableObject
{
    [SerializeField] public string LevelId;
    [SerializeField] public List<SavedObject> Prefabs = new();
}


[System.Serializable] 
public class SavedObject
{ 
    [SerializeField] public LevelObjectType ObjectType;
    [Header("Transform")]
    [SerializeField] public Vector3 Position;
    [SerializeField] public Quaternion Rotation;
    [SerializeField] public Vector3 Scale;
}
                                                                        