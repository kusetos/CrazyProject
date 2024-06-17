using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using Assets._Scripts.GamePlay;


public class GameManager : MonoBehaviour, IInitializable
{

    [Header("Game Zones")]
    [SerializeField] private GameObject _gameZoneBorder;
    [SerializeField] private GameObject _gamePlayZone;
    [Header("Level Setup")]
    [SerializeField] private string _levelPath;
    [Inject] private LevelDataManager _levelDataManager;
    
    [Inject] private GameTimer _gameTimer;
    

    public void Initialize()
    {
    }

    private void Awake()
    {
        _gameZoneBorder.SetActive(false);
        _gamePlayZone.SetActive(true);

        _levelDataManager.LevelPath = _levelPath;
        _levelDataManager.LoadLevel();
    }
    private void Start()
    {
        _gameTimer.StartTimer();
    }


}
