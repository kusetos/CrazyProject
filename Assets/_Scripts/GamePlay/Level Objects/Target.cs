using System.Collections;
using UnityEngine;
using System;
using Zenject;
using Assets._Scripts.GamePlay;

namespace Assets._Scripts.GamePlay
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]


    public class Target : GameLevelObject, IDamageable
    {
        [SerializeField] private float _scoreValue = 100f;
        [SerializeField] private float _fadeDuration = 1;

        public static Action<float> OnTargetDamage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Ground")
                StartCoroutine(FadeTransition());

        }

        public void TakeDamage()
        {
            OnTargetDamage?.Invoke(_scoreValue);
            this.gameObject.SetActive(false);
        }

        private IEnumerator FadeTransition()
        {
            Vector3 startScale = transform.localScale;
            float elapsedTime = 0f;

            while (transform.localScale.x >= 0.01)
            {
                elapsedTime += Time.deltaTime;
                transform.localScale = Vector3.Lerp(startScale, Vector3.zero, elapsedTime / _fadeDuration);
                yield return null;
            }
            TakeDamage();
            Debug.Log("Start damage");

        }
    }
}