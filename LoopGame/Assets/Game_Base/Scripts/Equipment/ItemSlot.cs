using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;
    public Sprite emptySprite;
    public ItemType itemType;

    int sceneIndex;

    [SerializeField] private Image itemImage;

    [SerializeField] private EquippedSlot armorSlot, mainHandSlot, jewelrySlot;
    public GameObject selectedShader;
    public bool thisItemSelected;


    private InventoryManager inventoryManager;
    private EquipmentSOlibrary equipmentSOlibrary;


    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        inventoryManager = GameObject.Find("GearUI").GetComponent<InventoryManager>();
        equipmentSOlibrary = GameObject.Find("GearUI").GetComponent<EquipmentSOlibrary>();
    }

    void Update()
    {

    }
    public void AddItem(string itemname, Sprite itemSprite, ItemType itemType)
    {
        this.itemType = itemType;
        this.itemName = itemname;
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        isFull = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
    public void OnLeftClick()
    {
        if (isFull)
        {

            if (thisItemSelected)
            {
                EquipGear();
                GameManager.instance.slots += 1;
                EmptySlot();
            }
            else
            {
                inventoryManager.DeselectAllSlots();
                selectedShader.SetActive(true);
                thisItemSelected = true;

                for (int i = 0; i < equipmentSOlibrary.itemSOs.Length; i++)
                {
                    if (equipmentSOlibrary.itemSOs[i].itemName == this.itemName)
                    {
                        equipmentSOlibrary.itemSOs[i].PreviewEquipment();
                    }
                }
            }
        }
        else 
        {
            PlayerManager.instance.TurnOffPreviewStats();
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }

    }
    private void EquipGear()
    {
        if(itemType == ItemType.armor)
        {
            armorSlot.EquipGear(itemSprite, itemName);
        }
        if (itemType == ItemType.mainHand)
        {
            mainHandSlot.EquipGear(itemSprite, itemName);
        }
        if (itemType == ItemType.jewelry)
        {
           jewelrySlot.EquipGear(itemSprite, itemName);
        }
        EmptySlot();

    }
    private void EmptySlot()
    {
        itemImage.sprite = emptySprite;
        itemName = string.Empty;

        isFull = false;
    }

    public void OnRightClick()
    {
          if (GameManager.instance.inShop)
         {
        if (isFull) { 
            int numRandom;
            numRandom = UnityEngine.Random.Range(5, 12) + CoinAndScore.instance.score/2;
            CoinAndScore.instance.AddCoins(numRandom);
            EmptySlot();
                GameManager.instance.slots += 1;
    }
       }
}
}