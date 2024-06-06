using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Shooting : MonoBehaviour
{
    [Header("BULLET")]
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private GameObject _bulletContainer;
    [SerializeField] private int _bulletPreloadCount;

    [Header("Wearpon")]
    [SerializeField] private GameObject _bulletOrigin;  
    [SerializeField] private int _ammoCount = 5;
    [SerializeField] private float _attackRate;
    [SerializeField] private float _bulletSpeed = 10f;

    //private int _bulletCount = 0;
    [Inject] private UIGameManager _uiManager;

    private Vector3 _mousePos;
    private PoolBase<Bullet> _bulletPool;
    private float _timer;
    private bool _reloaded => _timer > _attackRate;


    public float GetTimer => _timer;
    public int GetAmmoCount => _ammoCount;
    private void Awake()
    {
        _timer = _attackRate;
        _bulletPreloadCount = _ammoCount / 2;
        _bulletPool = new PoolBase<Bullet>(Preload, GetAction, ReturnAction, _bulletPreloadCount);

    }
    private void Update()
    {
        if (!_reloaded) _timer += Time.deltaTime;
        
        if (_ammoCount <= 0) return;

        if (Input.GetButtonUp("Fire1"))
        {
            
            Shoot();
            _ammoCount--;
            _uiManager.UpdateAmmoText();
            _timer = 0;
        }

    }
    private void Shoot()
    {
        _mousePos = Input.mousePosition;
        _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, Camera.main.farClipPlane));

        Bullet bullet = _bulletPool.Get();

        bullet.transform.position = _bulletOrigin.transform.position;
        bullet.transform.rotation = Quaternion.LookRotation(_mousePos - bullet.transform.position);
        

        var _rigidbody = bullet.GetComponent<Rigidbody>();
        _rigidbody.velocity = _rigidbody.transform.forward * _bulletSpeed;
        
        void OnReachTarget() => _bulletPool.Return(bullet);
        bullet.RemoveAction(OnReachTarget);
    }



    public Bullet Preload() => Instantiate(_bulletPrefab, _bulletContainer.transform);
    public void GetAction(Bullet bullet) => bullet.gameObject.SetActive(true);
    public void ReturnAction(Bullet bullet) => bullet.gameObject.SetActive(false);

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log($"on drag");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"on BEGIN drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log($"on END drag");
    }
}
