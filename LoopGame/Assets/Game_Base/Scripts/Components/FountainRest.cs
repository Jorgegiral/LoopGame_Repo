using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FountainRest : MonoBehaviour
{

    private bool isPlayerinCollider;
    private Animator fountanim;
    public GameObject shop;
    private PlayerInput playerInput;

    private void Start()
    {
        fountanim = GetComponent<Animator>();
        playerInput = FindObjectOfType<PlayerInput>();
    }
    /*private void Update()
    {
        if (isPlayerinCollider && fountanim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                fountanim.SetTrigger("Interact");
                AudioManager.Instance.PlaySFX(6);
                GameManager.instance.levelCompleted = true;
                PlayerManager.instance.AddPotions(1);
                CoinAndScore.instance.AddCoins(15);
                
            }
        }
    }*/
    public void HandleInteract(InputAction.CallbackContext context)
    {
       if (isPlayerinCollider && fountanim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
       {
           if (context.started)
           {
               fountanim.SetTrigger("Interact");
               AudioManager.Instance.PlaySFX(6);
               GameManager.instance.levelCompleted = true;
               PlayerManager.instance.AddPotions(1);
               CoinAndScore.instance.AddCoins(15);

           }
       }
   }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") ) 
        {
            
            isPlayerinCollider = true;

                shop.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shop.SetActive(false);
            isPlayerinCollider = false;
        }
    }
}
