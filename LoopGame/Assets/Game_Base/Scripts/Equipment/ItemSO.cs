using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public float health, attack, speed, jump, dashSpeed, dashRange, DashCD, attackCD;
    public Sprite itemSprite;


    public void PreviewEquipment()
    {
        PlayerManager.instance.PreviewEquipmentStats(itemName,attack, health,speed,jump,dashSpeed,dashRange,DashCD,attackCD);
    }


    
    public void EquipItem()
    {


            PlayerManager.instance.playerDamage += attack;
            PlayerManager.instance.playerMaxHealth += health;
            PlayerManager.instance.currentHealth += health;
            PlayerManager.instance.speed += speed;
            PlayerManager.instance.jumpForcePlayer += jump;
            PlayerManager.instance.dashingpower += dashSpeed;
            PlayerManager.instance.dashingrange += dashRange;
            PlayerManager.instance.dashCD -= DashCD;
            PlayerManager.instance.attackColdown -= attackCD;
            PlayerManager.instance.UpdateEquipmentStats();
            Debug.Log("Stats Changed");
            PlayerManager.instance.statsChanged = true;

        


    }
    public void UnEquipItem()
    {

        PlayerManager.instance.playerDamage -= attack;
        PlayerManager.instance.playerMaxHealth -= health;
        PlayerManager.instance.currentHealth -= health;
        PlayerManager.instance.speed -= speed;
        PlayerManager.instance.jumpForcePlayer -= jump;
        PlayerManager.instance.dashingpower -= dashSpeed;
        PlayerManager.instance.dashingrange -= dashRange;
        PlayerManager.instance.dashCD += DashCD;
        PlayerManager.instance.attackColdown += attackCD;
        PlayerManager.instance.UpdateEquipmentStats();
}
   
}
