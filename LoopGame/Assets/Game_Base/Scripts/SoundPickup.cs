using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPickup : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(4);
        }
    }
}

