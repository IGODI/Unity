using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerBoss : MonoBehaviour
{
    public int damage;
    public bool destroyOnDamage;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void DoDamage(Demageable damageable)
    {
        damageable.TakeDamage(damage);
        if (destroyOnDamage)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("InimigoProximo", true);   
        }    
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Demageable damageable = collision.gameObject.GetComponent<Demageable>();
        if (damageable != null)
        {
            DoDamage(damageable);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("InimigoProximo", false);
    }
}
