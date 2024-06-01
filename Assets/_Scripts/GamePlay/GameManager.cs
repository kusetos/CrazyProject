using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private TextMeshProUGUI _timerText;

    [Inject]
    private GameTimer _gameTimer;

    private void Start()
    {
        _gameTimer.StartTimer();
    }
    private void Update()
    {
        _gameTimer.Tick();
        Debug.Log($"Time: {_gameTimer.GetElapsedTime}");
    }
}
