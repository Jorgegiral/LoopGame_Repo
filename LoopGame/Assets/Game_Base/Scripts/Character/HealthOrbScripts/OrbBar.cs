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
    [SerializeField] private Sprite FullHP, AboveHalfHP, HalfHP, BelowHalfHP, NoHP;

    #endregion

    #region UnityFunctions
    private void Start()
    {
        halfHPCalculator = playerHealth.startingHealth / 2;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<OrbHealth>();

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
        else if (playerHealth.currentHealth <= halfHPCalculator+0.5f && playerHealth.currentHealth >= halfHPCalculator - 0.5f)
        {
            currenthealth.sprite = HalfHP;
        }
        else if (playerHealth.currentHealth > halfHPCalculator)
        {
            currenthealth.sprite = AboveHalfHP;
        }
        else
        {
            currenthealth.sprite = BelowHalfHP;
        }
    }
#endregion
}