using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbBar : MonoBehaviour
{
    private Image HealthBar;

    private void Start()
    {
        HealthBar = GetComponent<Image>();
    }

    private void Update()
    {
        HealthBar.fillAmount = PlayerManager.instance.currentHealth / PlayerManager.instance.playerMaxHealth;
    }
}