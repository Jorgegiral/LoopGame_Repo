using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ArenaLocker : MonoBehaviour
{
    [SerializeField] GameObject arenalimit;
    [SerializeField] CinemachineVirtualCamera playercam;
    [SerializeField] CinemachineVirtualCamera bosscam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playercam.gameObject.SetActive(false);
            bosscam.gameObject.SetActive(true);
            arenalimit.SetActive(true);
        }
    }

}