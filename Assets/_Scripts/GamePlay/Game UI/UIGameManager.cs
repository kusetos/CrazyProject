using Assets._Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIGameManager : MonoBehaviour
{

    [Header("Timer")]
    [SerializeField] private TextMeshProUGUI _timerText;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [Header("Reload")]
    [SerializeField] private Slider _reloadBar;
    [SerializeField] private TextMeshProUGUI _reloadText;
    [Header("Ammo")]
    [SerializeField] private TextMeshProUGUI _ammoText;

    [Inject] private GameTimer _gameTimer;
    [Inject] private GameScore _gameScore;
    [Inject] private Shooting _player;

    private void Update()
    {
        _timerText.text = _gameTimer.GetCurrentTime();
        
        _reloadBar.value = _player.GetReloadTimer;
        if(_reloadBar.value >= 1) _reloadText.gameObject.SetActive(true);
        else _reloadText.gameObject.SetActive(false);

    }
    private void OnEnable()
    {

        Target.OnTargetDamage += UpdateScoreUI;
        Shooting.OnShootAction += UpdateAmmoText;
        UpdateAmmoText();

    }
    private void OnDisable()
    {
        Target.OnTargetDamage -= UpdateScoreUI;
        Shooting.OnShootAction -= UpdateAmmoText;

    }

    public void UpdateScoreUI(float scoreValue)
    {
        _gameScore.AddScore(scoreValue);
        _scoreText.text = _gameScore.GetCurrentScore.ToString() ;
    }
    public void UpdateAmmoText()
    {
        _ammoText.text = _player.GetAmmoCount.ToString() ;
    }
}
