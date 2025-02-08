using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement; //Librería para que funcione el New Input System

public class PlayerController2D : MonoBehaviour
{

    //Referencias generales
    Rigidbody2D playerRb; //Ref al rigidbody del player 
    PlayerInput playerInput; //Ref al gestor del input del jugador
    Animator playerAnim; //Ref al animator para gestionar las transiciones de animaci?n

    private Vector2 moveInput;
    public float hitForce;
    private bool damaged;
    public float damageCooldown = 2f;
    bool isGod = false;

    [Header("Movement Parameters")]
    public float speed;

    [SerializeField] bool isFacingRight;

    [Header("Jump Parameters")]
    public float jumpForce;

    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;

    [Header("Respawn Parameters")]
    public Transform respawnPoint;
    //public SceneChanger sceneManagerScript;
    public string gameOverScene;

    [Header("Dash Parameters")]
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 8f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 3f;
    [SerializeField] TrailRenderer trail;



    void Start()
    {
        //Autoreferenciarcomponentes: nombre de variable = GetComponent
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerAnim = GetComponent<Animator>();
        isFacingRight = true;
    }

    void Update()
    {
        HandleAnimations();
        GroundCheck();

        if (isDashing) { return; }

        //Flip
        if (moveInput.x > 0)
        {
            if (isFacingRight)
            {
                Flip();
            }
        }
        if (moveInput.x < 0)
        {
            if (!isFacingRight)
            {
                Flip();
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDashing) { return; }

        Movement();
    }
    void Movement()
    {
        if (!damaged)
        {
            playerRb.velocity = new Vector2(moveInput.x * speed, playerRb.velocity.y);
        }
    }


    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight; //nombre de bool = !nombre de bool (cambio al estado contrario)
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Enemy") && !isGod)
            {
                Vector2 hit = (transform.position - collision.transform.position).normalized;
                playerRb.velocity = Vector2.zero;
                playerRb.AddForce(new Vector2(hit.x * hitForce, Mathf.Abs(hitForce * 0.5f)), ForceMode2D.Impulse);
                StartCoroutine(InvulnerabilityCoroutine());
            }
        }
    }*/

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void HandleAnimations()
    {
        playerAnim.SetBool("isJumping", !isGrounded);
        playerAnim.SetFloat("VelocityY", playerRb.velocity.y);
        playerAnim.SetBool("isRunning", Mathf.Abs(moveInput.x) > 0.1f);

    }

    IEnumerator InvulnerabilityCoroutine()
    {
        isGod = true;
        damaged = true;

        yield return new WaitForSeconds(0.5f); 
        damaged = false;
        yield return new WaitForSeconds(damageCooldown - 0.5f);

        isGod = false;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = playerRb.gravityScale;
        playerRb.gravityScale = 0f;
        float dashDirection = isFacingRight ? -1f : 1f;
        playerRb.velocity = new Vector2(dashDirection * dashingPower, 0f);
        trail.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trail.emitting = false;
        playerRb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    #region Input Events

    public void HandleMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isGrounded)
            {
                //AudioManager.Instance.PlaySFX(0);
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
    public void HandleAttack(InputAction.CallbackContext context)
    {
       
    }

    public void HandleDash(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StartCoroutine(Dash());
        }
    }

    #endregion



}
