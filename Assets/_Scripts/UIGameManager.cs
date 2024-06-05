using Assets._Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIGameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [Header("Reload")]
    [SerializeField] private Slider _reloadBar;
    [SerializeField] private TextMeshProUGUI _reloadText;

    [Inject] private GameTimer _gameTimer;
    [Inject] private GameScore _gameScore;
    [Inject] private Shooting _player;

    private void Update()
    {
        //_gameTimer.Tick();
        _timerText.text = _gameTimer.GetLeftSeconds();
        
        _reloadBar.value = _player.GetTimer;
        if(_reloadBar.value >= 1) _reloadText.gameObject.SetActive(true);
        else _reloadText.gameObject.SetActive(false);

    }
    public void UpdateScoreUI()
    {
        _scoreText.text = _gameScore.GetCurrentScore.ToString() ;
    }
}
