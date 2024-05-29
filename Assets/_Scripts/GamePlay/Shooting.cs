using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Bullet _bullet;
    [SerializeField]
    private float _bulletSpeed = 10f;

    private Vector3 _mousePos;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        _mousePos = Input.mousePosition;
        _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, Camera.main.farClipPlane));

        SpawnBullet();
    }
    private void SpawnBullet()
    {
        Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.LookRotation(_mousePos, Vector3.up));

        var _rigidbody = bullet.GetComponent<Rigidbody>();
        _rigidbody.velocity = _rigidbody.transform.forward * _bulletSpeed;

    }
}
