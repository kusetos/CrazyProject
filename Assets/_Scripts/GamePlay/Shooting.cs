using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Shooting : MonoBehaviour, IPointerClickHandler
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

    DrawTrajectory _trajectory;

    private Vector3 _mousePos;
    private PoolBase<Bullet> _bulletPool;
    private float _reloadTimer;
    private bool _reloaded => _reloadTimer > _attackRate;
    public bool AbleToShoot {  get; set; }

    public float GetReloadTimer => _reloadTimer;
    public int GetAmmoCount => _ammoCount;

    public static Action OnShootAction;

    private void OnEnable()
    {
        OnShootAction += Shoot;     
    }
    private void OnDisable()
    {
        OnShootAction -= Shoot;     
        
    }
    private void Awake()
    {
        AbleToShoot = true;
        _reloadTimer = _attackRate;
        _bulletPreloadCount = _ammoCount / 2;
        _bulletPool = new PoolBase<Bullet>(Preload, GetAction, ReturnAction, _bulletPreloadCount);
        _trajectory = GetComponent<DrawTrajectory>();
    }
    private void Update()
    {
        if (!_reloaded) _reloadTimer += Time.deltaTime;

        if (!AbleToShoot) return;
        
        if (Input.GetButton("Fire1"))
        {
            _bulletOrigin.GetComponent<MeshRenderer>().enabled = true;

            _mousePos = Input.mousePosition;
            _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, Camera.main.farClipPlane));
            
            _trajectory.UpdateTrajectory((_mousePos - _bulletOrigin.transform.position) * _bulletSpeed, _bulletPrefab.GetComponent<Rigidbody>(), _bulletOrigin.transform.position);
        }


        if (Input.GetButtonUp("Fire1"))
        {
            if (_ammoCount > 0)
            {
                _ammoCount--;
                OnShootAction?.Invoke();
                _trajectory.HideLine();
                _reloadTimer = 0;
            }
            else
            {
                Debug.Log("LOSE");
            }
        }

    }
    private void Shoot()
    {
        _bulletOrigin.GetComponent<MeshRenderer>().enabled = false;
        _mousePos = Input.mousePosition;
        _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(_mousePos.x, _mousePos.y, Camera.main.farClipPlane));

        Bullet bullet = _bulletPool.Get();

        bullet.transform.position = _bulletOrigin.transform.position;
        bullet.transform.rotation = Quaternion.LookRotation(_mousePos - bullet.transform.position);
        

        var rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce((_mousePos - bullet.transform.position) * _bulletSpeed);//.velocity = rigidbody.transform.forward * _bulletSpeed;
        
        void OnReachTarget() => _bulletPool.Return(bullet);
        bullet.RemoveAction(OnReachTarget);
    }

    public Bullet Preload() => Instantiate(_bulletPrefab, _bulletContainer.transform);
    public void GetAction(Bullet bullet) => bullet.gameObject.SetActive(true);
    public void ReturnAction(Bullet bullet) => bullet.gameObject.SetActive(false);

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Click {eventData}");
    }
}
