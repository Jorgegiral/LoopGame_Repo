using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainRest : MonoBehaviour
{

    private bool isPlayerinCollider;
    private Animator fountanim;


    private void Start()
    {
        fountanim = GetComponent<Animator>();   
    }
    private void Update()
    {
        if (isPlayerinCollider && fountanim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                fountanim.SetTrigger("Interact");
                GameManager.instance.levelCompleted = true;
                PlayerManager.instance.AddPotions(1);
                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") ) 
        {
            
            isPlayerinCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            isPlayerinCollider = false;
        }
    }
}
