using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbBar : MonoBehaviour
{
    #region Variables
    [Header("Orb Variables")]
    [SerializeField] private OrbHealth playerHealth;
    [SerializeField] private Image currenthealth;
    private float halfHPCalculator;

    [Header("Image Variables")]
    [SerializeField] private Sprite FullHP, NearlyFullHP, AboveHalfHP, HalfHP, BelowHalfHP, LowHP, VeryLowHP, NoHP;

    #endregion

    #region UnityFunctions
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<OrbHealth>();
        halfHPCalculator = playerHealth.startingHealth / 2;


    }
    private void Update()
    {
        ChangeImage();
    }
    #endregion

    #region Functions
    private void ChangeImage()
    {
        if (playerHealth.currentHealth >= playerHealth.startingHealth)
        {
            currenthealth.sprite = FullHP;
        }
        else if (playerHealth.currentHealth <= 0)
        {
            currenthealth.sprite = NoHP;
        }
        else if (playerHealth.currentHealth >= halfHPCalculator + 1f)
        {
            currenthealth.sprite = NearlyFullHP;
        }
        else if (playerHealth.currentHealth >= halfHPCalculator + 0.5f)
        {
            currenthealth.sprite = AboveHalfHP;
        }
        else if (playerHealth.currentHealth >= halfHPCalculator)
        {
            currenthealth.sprite = HalfHP;
        }
        else if (playerHealth.currentHealth >= halfHPCalculator - 0.5f)
        {
            currenthealth.sprite = BelowHalfHP;
        }
        else if (playerHealth.currentHealth >= halfHPCalculator - 1f)
        {
            currenthealth.sprite = LowHP;
        }
        else
        {
            currenthealth.sprite = VeryLowHP;
        }
    }
#endregion
}