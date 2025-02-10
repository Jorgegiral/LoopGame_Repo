using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //Librería para que funcione el New Input System

public class PlayerController2D : MonoBehaviour
{

    //Referencias generales
    Rigidbody2D playerRb; //Ref al rigidbody del player 
    PlayerInput playerInput; //Ref al gestor del input del jugador
    Animator playerAnim; //Ref al animator para gestionar las transiciones de animaci?n

    private Vector2 moveInput;
    public float hitForce = 2;

    [SerializeField] bool isFacingRight;
    [Header("Jump Parameters")]
    private float jumpForce;

    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] private Slider cooldownAttackSlider;
    [SerializeField] private Slider cooldownDashSlider;
    private float cooldowndashTimer = 0f;
    private float cooldownTimer = 0f;                      
    private bool canAttack = true;
    [Header("Respawn Parameters")]
    public Transform respawnPoint;
    public string gameOverScene;

    [Header("Dash Parameters")]
    private bool canDash = true;
    private bool isDashing;

    private float dashingCooldown = 3f;
    [SerializeField] TrailRenderer trail;



    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerAnim = GetComponent<Animator>();
        cooldownAttackSlider = GameObject.Find("AttackCD").GetComponent<Slider>();
        cooldownDashSlider = GameObject.Find("DashCD").GetComponent<Slider>();

        isFacingRight = true;


    }

    void Update()
    {
        HandleAnimations();
        GroundCheck();
        

        if (isDashing) { return; }
       
        if (!canAttack)
        {
            cooldownTimer += Time.deltaTime;
            UpdateAttackCooldownUI();


            if (cooldownTimer >= PlayerManager.instance.attackColdown)
            {
                canAttack = true;
                cooldownTimer = 0f;  
            }
        }
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

            playerRb.velocity = new Vector2(moveInput.x * PlayerManager.instance.speed, playerRb.velocity.y);
        
    }


    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight; 
    }

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

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = playerRb.gravityScale;
        playerRb.gravityScale = 0f;
        float dashDirection = isFacingRight ? -1f : 1f;
        playerRb.velocity = new Vector2(dashDirection * PlayerManager.instance.dashingpower, 0f);
        trail.emitting = true;
        cooldowndashTimer = 0f;
        yield return new WaitForSeconds(PlayerManager.instance.dashingrange);
        trail.emitting = false;
        playerRb.gravityScale = originalGravity;
        isDashing = false;
        while (cooldowndashTimer < dashingCooldown)
        {
            cooldowndashTimer += Time.deltaTime;
            UpdateDashCooldownUI(); 
            yield return null;  
        }
        canDash = true;
    }
    private void Attack()
    {
        canAttack = false;
        playerAnim.SetTrigger("Attack");
        cooldownTimer = 0f;
    }

    private void UpdateAttackCooldownUI()
    {
        cooldownAttackSlider.value = cooldownTimer / PlayerManager.instance.attackColdown;

    }
    private void UpdateDashCooldownUI()
    {

        cooldownDashSlider.value = cooldowndashTimer / dashingCooldown;

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
                playerRb.AddForce(Vector2.up * PlayerManager.instance.jumpForce, ForceMode2D.Impulse);
            }
        }
    }
    public void HandleAttack(InputAction.CallbackContext context)
    {
        if (context.started && canAttack)
        {
           Attack();
        }
    }

    public void HandleDash(InputAction.CallbackContext context)
    {
        if (context.started && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    #endregion
    


}
