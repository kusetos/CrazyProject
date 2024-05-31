using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitRotation : MonoBehaviour
{
    [SerializeField] GameObject _objectToOrbit;

    [SerializeField] float _radius = 1;
    [SerializeField] float _degreesPerSecondX = 30;
    [SerializeField] float _degreesPerSecondY = 30;
    [SerializeField] float _degreesPerSecondZ = 30;
    [SerializeField]
    private float _angleX = 0;
    private float _angleY = 0;
    private float _angleZ = 0;

    private void Update()
    {
        _angleX += (_angleX > 360) ? -360 : _degreesPerSecondX * Time.deltaTime;
        _angleY += (_angleY > 360) ? -360 : _degreesPerSecondY * Time.deltaTime;
        _angleZ += (_angleZ > 360) ? -360 : _degreesPerSecondZ * Time.deltaTime;

        Vector3 orbit = Vector3.one * _radius;
        orbit = Quaternion.Euler(_angleX, _angleY, _angleZ) * orbit;

        transform.position =  _objectToOrbit.transform.position + orbit;

    }
}
