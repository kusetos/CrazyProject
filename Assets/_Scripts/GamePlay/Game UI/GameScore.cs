using System;
using UnityEngine;
using Zenject;

namespace Assets._Scripts.GamePlay
{
    public class GameScore : IInitializable
    {
        private float _currentScore;
        public float GetCurrentScore => _currentScore;
        public void Initialize()
        {
            _currentScore = 0f;
        }

        public void AddScore(float score)
        {
            _currentScore += score;
        }

    }
}
