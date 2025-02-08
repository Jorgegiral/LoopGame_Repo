using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Fountain : MonoBehaviour
{
    private int score;
    [SerializeField] GameObject tutorial;
    [SerializeField] GameObject potionShop;
    private bool isPlayerinCollider;
    private int potionCost  = 15;

    private void Awake()
    {

        
    }
    private void Update()
    {
        if (isPlayerinCollider)
        {
            if (Input.GetKeyDown("F") && GameManager.instance.coins >= potionCost)
            {
                GameManager.instance.coins -= potionCost;
                GameManager.instance.potions += 1;
            }   
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && score == 0)
        {
            tutorial.SetActive(true);
        }
        else if (collision.CompareTag("Player") && score > 0) 
        {
            potionShop.SetActive(true);
            isPlayerinCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && score == 0)
        {
            tutorial.SetActive(false);
        }
        else if (collision.CompareTag("Player") && score > 0)
        {
            potionShop.SetActive(false);
            isPlayerinCollider = false;

        }
    }




}
