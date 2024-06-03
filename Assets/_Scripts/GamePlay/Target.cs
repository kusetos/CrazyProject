using System.Collections;
using UnityEngine;

namespace Assets._Scripts.GamePlay
{
    public class Target : MonoBehaviour, IDamageable
    {
        public void TakeDamage()
        {
            gameObject.SetActive(false);
        }
    }
}