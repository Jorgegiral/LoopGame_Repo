using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    bool playerinCollider;
    public GameObject shop;
    /*private void Update()
    {
        if (playerinCollider && GameManager.instance.dailyVisit == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                SceneShop();

            }
        }
    }*/

    public void HandleShop(InputAction.CallbackContext context)
    {
        if (playerinCollider && GameManager.instance.dailyVisit == true)
        {
            if (context.started)
            {
                SceneShop();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerinCollider = true;
            shop.SetActive(true);
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerinCollider = false;
            shop.SetActive(false);
        }
    }
    public void SceneShop()
    {
        SceneManager.LoadScene(5);
    }
}
