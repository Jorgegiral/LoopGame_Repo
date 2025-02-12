using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatHolder : MonoBehaviour
{

    [SerializeField] TMP_Text attackText, healthText, attackCDText, speedText, jumpText, dashSpeedText, dashRangeText, dashCDText;

    [SerializeField] TMP_Text attackpreText, healthpreText, attackCDpreText, speedpreText, jumppreText, dashSpeedpreText, dashRangepreText, dashCDpreText;
    [SerializeField] Image previewImage;
    [SerializeField] GameObject selectedItemStats;
    [SerializeField] GameObject selectedItemImage;

    private void Start()
    {
        UpdateEquipmentStats();
    }
    public void UpdateEquipmentStats()
    {
        attackText.text = PlayerManager.instance.playerDamage.ToString();
        healthText.text = PlayerManager.instance.playerMaxHealth.ToString();
        attackCDText.text = PlayerManager.instance.attackColdown.ToString();
        speedText.text = PlayerManager.instance.speed.ToString();
        jumpText.text = PlayerManager.instance.jumpForcePlayer.ToString(); ;
        dashRangeText.text = PlayerManager.instance.dashingrange.ToString();
        dashSpeedText.text = PlayerManager.instance.dashingpower.ToString();
        dashCDText.text = PlayerManager.instance.dashCD.ToString();
    }
    public void PreviewEquipmentStats(float attack, float health, float speed, float jump, float dashSpeed, float dashRange,float dashCD, float attackCD)
    {
        attackpreText.text = attack.ToString();
        healthpreText.text = health.ToString();
        attackCDpreText.text = attackCD.ToString();
        speedpreText.text = speed.ToString();
        jumppreText.text = jump.ToString(); ;
        dashRangepreText.text = dashRange.ToString();
        dashSpeedpreText.text = dashSpeed.ToString();
        dashCDpreText.text = dashCD.ToString();
        selectedItemStats.SetActive(true);
        selectedItemImage.SetActive(true);
    }
    public void TurnOffPreviewStats()
    {
        selectedItemImage.SetActive
            (false);
        selectedItemStats.SetActive (false);
    }
}
