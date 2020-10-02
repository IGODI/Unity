using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public int damage;
    public bool destroyOnDamage;

    void DoDamage(Demageable damageable)
    {
        damageable.TakeDamage(damage);
        if (destroyOnDamage)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Demageable damageable = other.gameObject.GetComponent<Demageable>();
        if(damageable != null)
        {
            DoDamage(damageable);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Demageable damageable = other.GetComponent<Demageable>();
        if (damageable != null)
        {
            DoDamage(damageable);
        }
    }

}
