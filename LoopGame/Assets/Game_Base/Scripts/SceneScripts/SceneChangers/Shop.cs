using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    bool playerinCollider;
    private void Update()
    {
        if (playerinCollider && GameManager.instance.dailyVisit == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
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
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerinCollider = false;
        }
    }
    public void SceneShop()
    {
        SceneManager.LoadScene(5);
    }
}
