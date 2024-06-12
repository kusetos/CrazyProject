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

    //private int _bulletCount = 0;
    [Inject] private UIGameManager _uiManager;

    private Vector3 _mousePos;
    private PoolBase<Bullet> _bulletPool;
    private float _timer;
    private bool _reloaded => _timer > _attackRate;
    public bool AbleToShoot {  get; set; }

    public float GetReloadTimer => _timer;
    public int GetAmmoCount => _ammoCount;
    private void Awake()
    {
        AbleToShoot = true;
        _timer = _attackRate;
        _bulletPreloadCount = _ammoCount / 2;
        _bulletPool = new PoolBase<Bullet>(Preload, GetAction, ReturnAction, _bulletPreloadCount);
        _trajectory = GetComponent<DrawTrajectory>();
    }
    private void Update()
    {
        if (!_reloaded) _timer += Time.deltaTime;

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
            
            Shoot();
            _trajectory.HideLine();
            _ammoCount--;
            _uiManager.UpdateAmmoText();
            _timer = 0;
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
