using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //Item data
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    public ItemType itemType;
    //Item slot
    [SerializeField] private Image itemImage;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;


    void Start()
    {
        inventoryManager = GameObject.Find("GearUI").GetComponent<InventoryManager>();
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
        if (thisItemSelected)
        {           
          bool usable = inventoryManager.UseItem(itemName);
            if (usable)
            {
                EmptySlot();
            }
        }
        else
        {
            inventoryManager.DeseleectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
           
        }
    
}

    private void EmptySlot()
    {
        itemImage.sprite = emptySprite;

        isFull = false;
    }

    public void OnRightClick()
    {
        if (GameManager.instance.inShop)
        {
            int numRandom;
            numRandom = UnityEngine.Random.Range(5, 12) + GameManager.instance.score/2;
            GameManager.instance.AddCoins(numRandom);
            EmptySlot();
        }
    }
}