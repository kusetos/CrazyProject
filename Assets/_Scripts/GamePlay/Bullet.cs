using UnityEngine;

internal class Bullet : MonoBehaviour
{

    private void Update()
    {
        if(transform.position.y < -1)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable != null)
        {                                                         
            damageable.TakeDamage();
            gameObject.active = false;
        }                                      

    }


}