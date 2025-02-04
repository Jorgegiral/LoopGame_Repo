using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    #region Variables

    [SerializeField] Rigidbody2D playerRb; 
    [SerializeField] PlayerInput playerInput; 
    //[SerializeField] Animator playerAnim; 

    [Header("Movement Parameters")]
    private Vector3 moveInput;
    [SerializeField] float speed;
    [SerializeField] bool isFacingLeft;

    [Header("Jump Parameters")]
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;


    #endregion
    #region UnityFunctions

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRb = GetComponent<Rigidbody2D>();
        //playerAnim = GetComponent<Animator>();
        isFacingLeft = true;
    }

    void Update()
    {
        Flip();
        GroundCheck();
        Movement();
    }

    #endregion
    #region Functions
    void Movement()
    {
        playerRb.velocity = new Vector2(moveInput.x * speed, playerRb.velocity.y);
    }

    void Flip()
    {
        if ((moveInput.x > 0 && isFacingLeft) || (moveInput.x < 0 && !isFacingLeft))
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;
            isFacingLeft = !isFacingLeft;
        }
    }
  /*  void HandleAnimations()
    {
        //Conector de valores generales con parámetros de cambios de animación
        playerAnim.SetBool("isJumping", !isGrounded);
        if (moveInput.x != 0)
        {
            playerAnim.SetBool("isRunning", true);
        }
        else
        {
            playerAnim.SetBool("isRunning", false);

        }
    }
  */
    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    #endregion
    #region InputEvents

    public void HandleMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

    }
    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }
    }

    #endregion
}
