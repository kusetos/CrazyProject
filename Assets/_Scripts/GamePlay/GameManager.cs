using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timerText;
    [SerializeField] private float _timerTime;

    [Inject]
    private GameTimer _gameTimer;

    private void Start()
    {
        _gameTimer.StartTimer(_timerTime);
    }
    private void Update()
    {
        //_gameTimer.Tick();
        _timerText.text = _gameTimer.GetLeftSeconds();
        
    }
}
