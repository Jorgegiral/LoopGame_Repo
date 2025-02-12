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
    //Item data
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    public ItemType itemType;
    int sceneIndex;

    //Item slot
    [SerializeField] private Image itemImage;
    //Equipped slot
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

    // Update is called once per frame
    void Update()
    {

    }
    public void AddItem(string itemname, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        this.itemType = itemType;
        this.itemName = itemname;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
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
            armorSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        if (itemType == ItemType.mainHand)
        {
            mainHandSlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        if (itemType == ItemType.jewelry)
        {
           jewelrySlot.EquipGear(itemSprite, itemName, itemDescription);
        }
        EmptySlot();

    }
    private void EmptySlot()
    {
        itemImage.sprite = null;
        itemName = string.Empty;
        itemDescription = string.Empty;

        isFull = false;
    }

    public void OnRightClick()
    {
          if (sceneIndex == 5)
         {
        if (isFull) { 
            int numRandom;
            numRandom = UnityEngine.Random.Range(5, 12) + GameManager.instance.score/2;
            GameManager.instance.AddCoins(numRandom);
            EmptySlot();
        Debug.Log(numRandom);
    }
       }
}
}