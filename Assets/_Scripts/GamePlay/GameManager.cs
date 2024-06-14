using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using Assets._Scripts.GamePlay;


public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _gameZoneBorder;
    [SerializeField] private GameObject _gamePlayZone;
    [SerializeField] private AllLevelData _allLevelData;


    [SerializeField] private float _timerTime;
    [Inject] private GameTimer _gameTimer;
    [Inject] private GameScore _gameScore;

    private void Awake()
    {
        _gameZoneBorder.SetActive(false);
        _gamePlayZone.SetActive(true);
    }
    private void Start()
    {
        _gameTimer.StartTimer(_timerTime);
    }


}
