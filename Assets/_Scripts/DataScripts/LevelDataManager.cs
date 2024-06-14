using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    [SerializeField] private int _levelIndex;
    [SerializeField] private List<SaveLevelPrefab> _savePrefabs;
    public void SaveLevel()
    {
        var newLevel = ScriptableObject.CreateInstance<ScriptableLevel>();
        newLevel.LevelId = _levelIndex;
        newLevel.name = $"Level {_levelIndex}";

        LevelObject[] levelObjects = FindObjectsOfType<LevelObject>();
        foreach( LevelObject levelObject in levelObjects)
        {

            newLevel.Prefabs.Add(
        new SavedObject
        {
            Object = levelObject,
            Position = levelObject.transform.position,
            Rotation = levelObject.transform.rotation,
            Scale = levelObject.transform.localScale
            });
                Debug.Log($"{levelObject.transform.position}");
        }
    
        ScriptableObjectUtility.SaveLevelFile(newLevel);


    }
    public void ClearLevel()
    {
        LevelObject[] levelObjects = FindObjectsOfType<LevelObject>();
        foreach (LevelObject levelObject in levelObjects)
        {
            if (levelObject == null) continue;

            if (Application.isEditor) 
                DestroyImmediate(levelObject.gameObject);
            else 
                Destroy(levelObject.gameObject);
        }
    }
    public void LoadLevel()
    {
        var level = Resources.Load<ScriptableLevel>($"Levels/Level {_levelIndex}");
        if (level == null) 
        {
            Debug.LogError($"Levels/Level {_levelIndex} does not exist"); 
            return; 
        }
        ClearLevel();

        GameObject prefab = null;
        foreach(var levelObject in level.Prefabs)
        {
            foreach (var savePrefabs in _savePrefabs)
            {
                if (levelObject.Object.ObjectType == savePrefabs.ObjectType)
                {
                    prefab = savePrefabs.Prefab;
                    break;
                }

            }
            if(prefab == null)
            {
                Debug.LogError($"Prefab couldnt found! {levelObject.Object.ObjectType}");
                continue;
            }
            GameObject gameObject = Instantiate(prefab);
            gameObject.transform.position = levelObject.Position;
            gameObject.transform.rotation = levelObject.Rotation;
            gameObject.transform.localScale = levelObject.Scale;
        }

    }
}
[System.Serializable]
public class SaveLevelPrefab
{
    public LevelObjectType ObjectType;
    public GameObject Prefab;
}

#if UNITY_EDITOR
public static class ScriptableObjectUtility
{
    public static void SaveLevelFile(ScriptableLevel level)
    {
        AssetDatabase.CreateAsset(level, $"Assets/Resources/Levels/{level.name}.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
#endif
