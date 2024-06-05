using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("BULLET")]
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 10f; 
    [SerializeField] private float _attackRate; 
    [SerializeField] private int _bulletPreloadCount;

    [SerializeField] private GameObject _bulletContainer;

    private int _bulletCount = 0;
    private Vector3 _mousePos;
    private PoolBase<Bullet> _bulletPool;
    private float _timer;

    public float GetTimer => _timer;
    private void Awake()
    {
        _timer = _attackRate;
        _bulletPool = new PoolBase<Bullet>(Preload, GetAction, ReturnAction, _bulletPreloadCount);

    }
    private void Update()
    {
        if(_timer < _attackRate) _timer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && _timer >= _attackRate)
        {
            Shoot();
            _bulletCount++;
            _timer = 0;
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
