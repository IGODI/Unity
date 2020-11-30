using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public Transform shotSpawner;
    public Rigidbody2D shot;
    public float shotSpeed = 15; //velocidade do tiro
    public float fireRate = 0.15f; //tempo de cada tiro
    public float totalCharge = 3; //tamanho de tiro carregado
    public float totalChargeTime = 2; //tempo de tiro carregado

    public float charging = 1;
    private float nextFire;
    private InputAction.CallbackContext shootphase; //tiro
    private PlayerMovement playerMovement;
    private Animator animator;

    public AudioSource audioSource;
    public AudioClip ShootingAudioClip;



    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(shootphase.started) 
        {
            charging += Time.deltaTime * ((totalCharge - 1 / totalChargeTime));
        }

        charging = Mathf.Clamp(charging, 1, totalCharge);
    }
    public void OnShoot(InputAction.CallbackContext ctx)
    {
        shootphase = ctx;
        if(shootphase.canceled)
        {
            Shoot();
        }
    }
    void Shoot()
    {      
        if (Time.time < nextFire)
            return;

        animator.SetTrigger("Shoot");

        nextFire = Time.time + fireRate;
        Rigidbody2D newShot = Instantiate(shot, shotSpawner.position, Quaternion.identity);
        audioSource.PlayOneShot(ShootingAudioClip);

        newShot.velocity = Vector2.right * shotSpeed * playerMovement.direction;

        newShot.transform.localScale *= charging;
        charging = 1;

        
    }
}
