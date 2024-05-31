using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] _wayPoints;

    private int _index = 0;

    private void Start()
    {
        transform.position = _wayPoints[0].position;
    }
    private void Update()
    {
        if(Vector3.Distance(transform.position, _wayPoints[_index].position) < 0.1f)
        {
            _index = _index+1 == _wayPoints.Length ? 0 : _index += 1;
        }
        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_index].position,
                                            speed * Time.deltaTime);
    }
}
