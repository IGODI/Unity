using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float vel = 2.8f;
    Rigidbody2D rb;
    public Transform Player;
    Transform inimigoLocal;
    public Transform SpawnTiro;
    bool face;
    Animator anima;
    public GameObject Tiro;
    
    public float distancia;
    public float distancia2;
    public Vector3 RangeOffset;
    public Vector3 RangeOffset2;
    public LayerMask layerMask;
    public LayerMask layerMask2;
    public bool podeAtirar;

    public AudioSource audioSource;
    public AudioClip ShootingAudioClip;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inimigoLocal = GetComponent<Transform>();
        anima = GetComponent<Animator>();
        podeAtirar = true;
    }

    void Update()
    {

        if ((Player.transform.position.x > this.inimigoLocal.position.x) && !face)
        {
            Flip();
        }
        else if ((Player.transform.position.x < this.inimigoLocal.position.x) && face)
        {
            Flip();
        }

    }
    private void FixedUpdate()
    {
        seguir();
        RangeAttack();
    }
    void Flip()
    {
        face = !face;

        Vector3 scala = this.inimigoLocal.localScale;
        scala.x *= -1;
        this.inimigoLocal.localScale = scala;
    }

    void seguir()
    {

        Vector3 target = new Vector3(Player.position.x, rb.position.y);
        Vector3 newPos = Vector3.MoveTowards(rb.position, target, vel * Time.fixedDeltaTime);

        Vector3 pos = transform.position;
        pos += transform.right * RangeOffset.x;
        pos += transform.up * RangeOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, distancia, layerMask);
        if (colInfo != null)
        {            
            rb.MovePosition(newPos);
        }
    }
    void RangeAttack()
    {
        Vector3 pos2 = transform.position;
        pos2 += transform.right * RangeOffset2.x;
        pos2 += transform.up * RangeOffset2.y;

        Collider2D colInfo2 = Physics2D.OverlapCircle(pos2, distancia2, layerMask2);
        if (colInfo2 != null)
        {
            if (podeAtirar == true)
            {
                anima.SetBool("Longe", true);
            }
            else
            {
                anima.SetBool("Longe", false);
            }
        }
        else
        {
            anima.SetBool("Longe", false);
        }
    }
    void InvocarTiro()
    {
        GameObject newShot = Instantiate(Tiro, SpawnTiro);
        audioSource.PlayOneShot(ShootingAudioClip);
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * RangeOffset.x;
        pos += transform.up * RangeOffset.y;

        Gizmos.DrawWireSphere(pos, distancia);

        Vector3 pos2 = transform.position;
        pos2 += transform.right * RangeOffset2.x;
        pos2 += transform.up * RangeOffset2.y;

        Gizmos.DrawWireSphere(pos2, distancia2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            podeAtirar = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            podeAtirar = true;
        }
    }

}
