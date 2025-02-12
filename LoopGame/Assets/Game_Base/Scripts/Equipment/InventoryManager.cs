using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    private InventoryManager instance;
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    public EquippedSlot[] equippedSlot;
    public ItemSO[] itemSOs;

    private void Awake()
    {
            gameObject.SetActive(true);
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        
    }
    private void Update()
    {
        if (GameManager.instance.inShop)
        {
            if (Input.GetKeyDown(KeyCode.E) && menuActivated)
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