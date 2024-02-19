using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Banana
{
    public class SpawnView : MonoBehaviour
    {

        public void SpawnObjectAtRandom(GameObject prefab, float radius)
        {
            Vector3 randomPosition = Random.insideUnitCircle * radius;
            Instantiate( prefab, randomPosition, Quaternion.identity);
        }
    }
}