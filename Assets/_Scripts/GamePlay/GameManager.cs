using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using Assets._Scripts.GamePlay;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float _timerTime;

    [Inject] private GameTimer _gameTimer;
    [Inject] private GameScore _gameScore;

    private void Start()
    {
        _gameTimer.StartTimer(_timerTime);
    }

}
