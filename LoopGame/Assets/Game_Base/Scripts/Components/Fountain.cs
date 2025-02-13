using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Fountain : MonoBehaviour
{
    [SerializeField] GameObject tutorial;
    [SerializeField] GameObject potionShop;
    private bool isPlayerinCollider;
    private int potionCost  = 15;
    private Animator fuenteanim;

    private void Start()
    {
        fuenteanim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPlayerinCollider)
        {
            if (Input.GetKeyDown(KeyCode.F) && CoinAndScore.instance.coins >= potionCost)
            {
                AudioManager.Instance.PlaySFX(7);
                fuenteanim.SetTrigger("Interact");
                CoinAndScore.instance.AddCoins(-15);
                PlayerManager.instance.AddPotions(1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && CoinAndScore.instance.score == 0)
        {
            tutorial.SetActive(true);
        }
        else if (collision.CompareTag("Player") && CoinAndScore.instance.score > 0) 
        {
            potionShop.SetActive(true);
            isPlayerinCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && CoinAndScore.instance.score == 0)
        {
            tutorial.SetActive(false);
        }
        else if (collision.CompareTag("Player") && CoinAndScore.instance.score > 0)
        {
            potionShop.SetActive(false);
            isPlayerinCollider = false;

        }
    }




}
