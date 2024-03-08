using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Banana
{
   
    public class SpawnModel
    {
        [SerializeField] private int _count = 10;
        public int Count => _count;

        [SerializeField]  public GameObject _prefab;
        public GameObject Prefab => _prefab;

        [SerializeField] private float _radius = 10;
        public float Radius => _radius;
    }
}