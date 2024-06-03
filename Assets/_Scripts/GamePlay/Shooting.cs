using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("BULLET")]
    [SerializeField]
    private Bullet _bulletPrefab;
    [SerializeField]
    private float _bulletSpeed = 10f;
    [SerializeField]
    private float _attackRate;
    [SerializeField]
    private int _bulletPreloadCount;

    [SerializeField]
    private GameObject _bulletContainer;

    private int _bulletCount = 0;
    private Vector3 _mousePos;
    private PoolBase<Bullet> _bulletPool;
    private float _nextTimeAttack;
    private float _time;

    private void Awake()
    {
        _time = _attackRate;
        _bulletPool = new PoolBase<Bullet>(Preload, GetAction, ReturnAction, _bulletPreloadCount);

    }
    private void Update()
    {
        if(_time < _attackRate) _time += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && _time >= _attackRate)
        {
            Shoot();
            _bulletCount++;
            _time = 0;
            Debug.Log(_bulletCount);
        }
    }
    private void Shoot()
    {
        _mousePos = Input.mousePosition;
        _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, Camera.main.farClipPlane));

        Bullet bullet = _bulletPool.Get();

        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.LookRotation(_mousePos, Vector3.up);

        var _rigidbody = bullet.GetComponent<Rigidbody>();
        _rigidbody.velocity = _rigidbody.transform.forward * _bulletSpeed;
        
        void OnReachTarget() => _bulletPool.Return(bullet);
        bullet.RemoveAction(OnReachTarget);
    }

    public Bullet Preload() => Instantiate(_bulletPrefab, _bulletContainer.transform);
    public void GetAction(Bullet bullet) => bullet.gameObject.SetActive(true);
    public void ReturnAction(Bullet bullet) => bullet.gameObject.SetActive(false);

    
}
