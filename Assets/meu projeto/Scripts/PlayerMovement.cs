using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;  //Velocidade (é mesmo oh,não diga)
    public float horizontal; //Movimento
    private bool canMove = true;

    public bool JumpH;  //saber se ainda esta precionando o pulo
    private bool JumpStarted; //Auxilia o inicio do pulo
    public float JumpForce = 3; //Força do pulo( não vou nem falar nada)
    public bool taisjumpando; //para saber se continua pulando
    public float jumpHoldDuration = 0.15f;//Tempo do pulo
    private float JumpTime; //auxilio de controle do tempo do pulo
    public float JumpHoldForce =0f; //Força extra de pulo 

    public float coyoteduration = 0.1f;
    private float coyoteTime;

    public bool taisnnochao;//para saber se esta no solo
    public float leftFootOffset = -0.3f;
    public float rightFootOffset = 0.3f;
    public float groundOffset = 0.5f;
    public float groundDistance = 0.2f; //tamanho o reycast
    public LayerMask groundLayer;

    [Header("Ladder")]
    public float climbSpeed = 3; //velocidade de subir escada
    public LayerMask ladderMask; //mascara de camada
    public float vertical; //armazenamento doo input do exio da vertical
    public bool climbing; //indentifica se o jogador esta subindo escada
    public float checkRadius = 0.3f;
    private Transform ladder;

    public int direction = 1;
    private Rigidbody2D rb; //rigi do jogador
    private Animator animator;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GroundMovement();
        AirMovement();
        PhysicsCheck();
        ClimbLadder();
    }

    void PhysicsCheck() //checando colisão com o chão na esquerda e direita
    {
        taisnnochao = false;

        RaycastHit2D leftFoot = Raycast(new Vector2(leftFootOffset, -groundOffset), Vector2.down, groundDistance, groundLayer);
        RaycastHit2D rigthtFoot = Raycast(new Vector2(rightFootOffset, -groundOffset), Vector2.down, groundDistance, groundLayer);

        if (leftFoot || rigthtFoot)
        {
            taisnnochao = true;
        }

        animator.SetBool("OnGround", taisnnochao);
    }


    bool TouchingLadder()
    {
        return col.IsTouchingLayers(ladderMask); //se o jogador colidir com a escada
    }

    void ClimbLadder()
    {
        bool up = Physics2D.OverlapCircle(transform.position, checkRadius, ladderMask); //verifica se tem escada acima
        bool down = Physics2D.OverlapCircle(transform.position + new Vector3(0, -1), checkRadius, ladderMask);//verifica se tem escada abaixo 

        if(vertical != 0 && TouchingLadder())
        {
            climbing = true;
            rb.isKinematic = true;  //coloca o rigb como kinematic para evitar interferencia da fisisca
            canMove = false; //jogador não podera se mover para as laterias

            float xPos = ladder.position.x;

            transform.position = new Vector2(xPos, transform.position.y);
        }

        if (climbing) //Se não estiver escada acima ou abaixo, termina a escalada
        {
            if(!up && vertical >= 0)
            {
                FinishClimb();
                return;
            }

            if(!down && vertical <= 0)
            {
                FinishClimb();
                return;
            }

            float y = vertical * climbSpeed;
            rb.velocity = new Vector2(0, y);
        }
    }


     void FinishClimb()
    {
        
        climbing = false;
        rb.isKinematic = false;
        canMove = true;
    }



    void GroundMovement() //Ajuste na velocidade da movimentação do player
    {

        if (!canMove)
            return;
        
        float xVelocity = speed * horizontal;
        rb.velocity = new Vector2(xVelocity, rb.velocity.y);
        
        if(direction * xVelocity < 0)
        {
            Flip();
        }

        if (taisnnochao)
        {
            coyoteTime = Time.time + coyoteduration;
        }

        animator.SetFloat("Speed", Mathf.Abs(xVelocity));
    }


    public void Move(InputAction.CallbackContext ctx) 
    {
        horizontal = ctx.ReadValue<float>();
    }

    public void climb(InputAction.CallbackContext ctx)
    {
        vertical = ctx.ReadValue<float>();
    }

    void AirMovement() //auxilio do pulo chavoso
    {
        if(JumpStarted && (taisnnochao || coyoteduration >Time.time ))
        {
            taisjumpando = true;

            JumpStarted = false;

            rb.velocity = Vector2.zero;

            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

            JumpTime = Time.time + jumpHoldDuration;

            coyoteTime = Time.time;
        }
        if (taisjumpando)
        {
            if(JumpH)
            {
                rb.AddForce(Vector2.up * JumpHoldForce, ForceMode2D.Impulse);
            }
            if(JumpTime <= Time.time)
            {
                taisjumpando = false;
            }
        }

        JumpStarted = false;
    }
    public void Jump(InputAction.CallbackContext ctx) //Pulo chavoso
    {
        if(ctx.started)

        {
            JumpStarted = true;
        }

        JumpH = ctx.performed; 
    }

    void Flip()
    {
        direction *= -1;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask layerMask) //colisão
    {
        Vector2 pos = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, layerMask);

        Color color = hit ? Color.red : Color.green;

        Debug.DrawRay(pos + offset, rayDirection * length, color);

        return hit;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ladder"))
        {
            ladder = other.transform;
        }
    }
}
