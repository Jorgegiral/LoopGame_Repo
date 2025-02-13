using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    public EquippedSlot[] equippedSlot;
    public ItemSO[] itemSOs;



    public void HandleInventory()
    {

        if (menuActivated)
        {
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (!menuActivated)
        {
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public void AddItem(string itemName, Sprite itemSprite,  ItemType itemType)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            Debug.Log("Buscando item");
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, itemSprite,itemType);
                Debug.Log(" item= "+itemName);

            }

        }
        
    }
    public void DeselectAllSlots()
    {
        for (int i = 0;i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < equippedSlot.Length; i++)
        {
            equippedSlot[i].selectedShader.SetActive(false);
            equippedSlot[i].thisItemSelected = false;
        }
    }
}

public enum ItemType
{
    armor,
    jewelry,
    mainHand
};