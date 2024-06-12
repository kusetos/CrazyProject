using System.Collections;
using UnityEngine;
using Zenject;
using Assets._Scripts.GamePlay;

namespace Assets._Scripts.GamePlay
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]


    public class Target : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _scoreValue = 100f;
        [SerializeField] private float _fadeDuration = 1;

        [Inject] GameScore _gameScore;
        [Inject] UIGameManager _uiManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Ground")
            {
                StartCoroutine(FadeTransition());
            }
        }


        public void TakeDamage()
        {
            _gameScore.AddScore(_scoreValue);
            _uiManager.UpdateScoreUI();
            this.gameObject.SetActive(false);
            Debug.Log($"Damage \t Added Score: {_scoreValue}");
        }
        private IEnumerator FadeTransition()
        {
            Vector3 startScale = transform.localScale;
            float elapsedTime = 0f;

            yield return new WaitForSeconds(1);
            while (transform.localScale.x >= 0.01)
            {
                elapsedTime += Time.deltaTime;
                transform.localScale = Vector3.Lerp(startScale, Vector3.zero, elapsedTime / _fadeDuration);
                yield return null;
            }
            TakeDamage();


        }
    }
}