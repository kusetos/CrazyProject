using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//[CreateAssetMenu(fileName = "LevelData", menuName = "Level Data", order = 51)]
public class ScriptableLevel : ScriptableObject
{
    [SerializeField] public int LevelId;
    [SerializeField] public List<SavedObject> Prefabs = new();
}


[System.Serializable] 
public class SavedObject
{ 
    [SerializeField] public  LevelObject Object;
    [SerializeField] public Vector3 Position;
    [SerializeField] public Quaternion Rotation;
    [SerializeField] public Vector3 Scale;
}
                                                                        