using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class CircularRotation : MonoBehaviour
{
    [SerializeField]
    private float _rotation = 0;
    [SerializeField]
    private float _radius = 1;
    [SerializeField]
    private float _speed = 100;

    private void Update()
    {
        if( _rotation == 360)
        {
            _rotation = 0;
        }
        _rotation = _rotation + _speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, _rotation);
        transform.Translate(0, _radius * Time.deltaTime, 0);

    }
}
