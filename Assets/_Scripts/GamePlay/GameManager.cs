using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using Assets._Scripts.GamePlay;


public class GameManager : MonoBehaviour
{

    [Header("Game Zones")]
    [SerializeField] private GameObject _gameZoneBorder;
    [SerializeField] private GameObject _gamePlayZone;
    [Header("Level Setup")]
    [SerializeField] private string _levelPath;
    [Inject] private LevelDataManager _levelDataManager;
    
    [Inject] private GameTimer _gameTimer;

    private int _targetCount;
    private void OnEnable()
    {

        Target.OnTargetDamage += DecreaseTargetCount;
        
    }
    private void OnDisable()
    {
        Target.OnTargetDamage -= DecreaseTargetCount;
        
    }

    private void Awake()
    {
        _gameZoneBorder.SetActive(false);
        _gamePlayZone.SetActive(true);

        _levelDataManager.LevelPath = _levelPath;
        _levelDataManager.LoadLevel();
        _targetCount = _levelDataManager.GetTargetCount;

    }
    private void Start()
    {
        _gameTimer.StartTimer();
    }
    private void DecreaseTargetCount(float n)
    {
        if(_targetCount <= 0)
        {
            Debug.Log("WIN");
        }
        --_targetCount;
        Debug.Log($"Target count {_targetCount}");
    } 


}
