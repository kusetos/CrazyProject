using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    private float time;
    public Action OnReachTarget;
    public void RemoveAction(Action onReachTargetFunction)
    {
        OnReachTarget += onReachTargetFunction;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(transform.position.y < -1 || time >= _lifeTime)
        {
            time = 0;
            OnReachTarget();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable != null)
        {
            OnReachTarget();
            damageable.TakeDamage();
        }                                      

    }



}