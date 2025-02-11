using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject EquipmentMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    
    public ItemSO[] itemSOs;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName) 
            {
               bool usable = itemSOs[i].UseItem();
                return usable;
            }
            
        }
        return false;

    }
    public void AddItem(string itemName, Sprite itemSprite, string itemDescription,  ItemType itemType)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, itemSprite,itemDescription,itemType);
                return;
            }
        }
    }
    public void DeseleectAllSlots()
    {
        for (int i = 0;i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}

public enum ItemType
{
    armor,
    jewelry,
    mainHand
};