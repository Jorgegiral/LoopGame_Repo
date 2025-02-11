using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public AttributeToChange attributeToChange = new AttributeToChange();
    public float amountToChangeAttribute;

    public bool UseItem()
    {
          if (attributeToChange == AttributeToChange.playerMaxHealth)
          {
              PlayerManager.instance.ChangeHealth(amountToChangeAttribute);
          }
          if (attributeToChange == AttributeToChange.attackColdown)
          {
              PlayerManager.instance.ChangeAttackCD(amountToChangeAttribute);
          }
          if (attributeToChange == AttributeToChange.playerDamage)
          {
              PlayerManager.instance.ChangePlayerAttack(amountToChangeAttribute);
          }
          if (attributeToChange == AttributeToChange.jumpForce)
          {
              PlayerManager.instance.ChangeJumpForce(amountToChangeAttribute);
          }
          if (attributeToChange == AttributeToChange.speed)
          {
              PlayerManager.instance.ChangeSpeed(amountToChangeAttribute);
          }
          if (attributeToChange == AttributeToChange.dashspeed)
          {
              PlayerManager.instance.ChangeDashSpeed(amountToChangeAttribute);
          }
          if (attributeToChange == AttributeToChange.dashrange)
          {
              PlayerManager.instance.ChangeDashRange(amountToChangeAttribute);
          }
            return true;
       
    }
    public enum AttributeToChange
    {
        playerDamage,
        playerMaxHealth,
        attackColdown,
        jumpForce,
        speed,
        dashspeed,
        dashrange
    };
}
