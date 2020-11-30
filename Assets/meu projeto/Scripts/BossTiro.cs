using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTiro : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject Alvo;
    public float vel = 1.5f;
    public int damage;
    public bool destroyOnDamage;

    void DoDamage(Demageable damageable)
    {
        damageable.TakeDamage(damage);
        if (destroyOnDamage)
            Destroy(gameObject);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Alvo = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        Target();
    }
    void Target()
    {      
        Vector3 newPos = Vector3.MoveTowards(rb.position, Alvo.transform.position, vel * Time.fixedDeltaTime);

        rb.MovePosition(newPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Demageable damageable = collision.GetComponent<Demageable>();
        if (damageable != null)
        {
            DoDamage(damageable);
        }
        Destroy(gameObject);
    }
}
