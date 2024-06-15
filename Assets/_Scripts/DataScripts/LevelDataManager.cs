using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    [Header("Bullet Container")]
    [SerializeField] private Transform _levelContainer;
    [Header("Level Editor Preference")]
    [SerializeField] private string _levelPath;
    [SerializeField] private List<SaveLevelPrefab> _savePrefabs;

    private int _targetCount;
    public void SaveLevel()
    {
        var newLevel = ScriptableObject.CreateInstance<ScriptableLevel>();
        newLevel.LevelId = _levelPath;
        newLevel.name = $"{_levelPath}";

        GameLevelObject[] levelObjects = FindObjectsOfType<GameLevelObject>();
        foreach(GameLevelObject levelObject in levelObjects)
        {

            newLevel.Prefabs.Add(
        new SavedObject
            {
                ObjectType = levelObject.ObjectType,
                Position = levelObject.transform.position,
                Rotation = levelObject.transform.rotation,
                Scale = levelObject.transform.localScale
                });
            }
    
        ScriptableObjectUtility.SaveLevelFile(newLevel);


    }
    public void ClearLevel()
    {
        GameLevelObject[] levelObjects = FindObjectsOfType<GameLevelObject>();
        foreach (GameLevelObject levelObject in levelObjects)
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
        ScriptableLevel level = Resources.Load<ScriptableLevel>($"Levels/{_levelPath}");
        if (level == null) 
        {
            Debug.LogError($"Levels/{_levelPath} does not exist"); 
            return; 
        }
        ClearLevel();

        GameObject prefab = null;
        _targetCount = 0;
        foreach(var levelObject in level.Prefabs)
        {
            foreach (var savePrefabs in _savePrefabs)
            {

                if(levelObject.ObjectType == LevelObjectType.TARGET)
                {
                    _targetCount++;
                }
                if (levelObject.ObjectType == savePrefabs.ObjectType)
                {
                    prefab = savePrefabs.Prefab;
                    break;
                }

            }
            if(prefab == null)
            {
                Debug.LogError($"Prefab couldnt found! {levelObject.ObjectType}");
                continue;
            }
            GameObject gameObject = Instantiate(prefab, _levelContainer);
            gameObject.transform.position = levelObject.Position;
            gameObject.transform.rotation = levelObject.Rotation;
            gameObject.transform.localScale = levelObject.Scale;
        }

        Debug.Log($"Target count: {_targetCount}");
    }
}

[System.Serializable]
public struct SaveLevelPrefab
{
    [SerializeField] public LevelObjectType ObjectType ;
    [SerializeField] public GameObject Prefab;
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
