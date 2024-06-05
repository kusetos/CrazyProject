using System.Collections;
using UnityEngine;
using Zenject;
using Assets._Scripts.GamePlay;

namespace Assets._Scripts.GamePlay
{
    public class Target : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _scoreValue = 100f;
        [Inject] GameScore _gameScore;
        [Inject] UIGameManager _uiManager;

        private void Update()
        {
            if (transform.position.y < -10)
            {
                TakeDamage();

                gameObject.SetActive( false );
            }
        }


        public void TakeDamage()
        {
            //gameObject.SetActive(false);
            _gameScore.AddScore(_scoreValue);
            _uiManager.UpdateScoreUI();
            Debug.Log($"Damage \t Added Score: {_scoreValue}");
        }
    }
}