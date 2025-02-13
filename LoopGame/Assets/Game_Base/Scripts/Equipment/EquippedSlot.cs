using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class EquippedSlot : MonoBehaviour, IPointerClickHandler
{
    //slot appearence
    [SerializeField] private Image slotImage;

    //slot data
    [SerializeField] private ItemType itemType;
    private Sprite itemSprite;
    [SerializeField] string itemName;

    [SerializeField] bool slotInUse;
    public GameObject selectedShader;
    public bool thisItemSelected;
    [SerializeField] Sprite emptySprite;
    private InventoryManager inventoryManager;
    private EquipmentSOlibrary equipmentSOlibrary;
    [SerializeField] ItemSO[] itemSOs;

    private void Start()
    {
        
        inventoryManager = GameObject.Find("GearUI").GetComponent<InventoryManager>();
        equipmentSOlibrary = GameObject.Find("GearUI").GetComponent<EquipmentSOlibrary>();
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

    void OnLeftClick()
    {
        if (thisItemSelected && slotInUse)
        {
            UnEquipGear();
            GameManager.instance.slots -= 1;

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
    void OnRightClick()
    {
        UnEquipGear();
        EmptySlot();
    }
    public void EquipGear(Sprite itemsprite, string itemName)
    {
        if (slotInUse)
        {
            UnEquipGear();
            PlayerManager.instance.TurnOffPreviewStats();

        }
        this.itemSprite = itemsprite;
        slotImage.sprite = this.itemSprite;

        this.itemName = itemName;
        for (int i = 0; i < equipmentSOlibrary.itemSOs.Length; i++)
        {
            if (equipmentSOlibrary.itemSOs[i].itemName == this.itemName) 
            {
                Debug.Log($"Calling EquipItem for {this.itemName}");

                equipmentSOlibrary.itemSOs[i].EquipItem();
                slotInUse = true;
                
            }
        }
        PlayerManager.instance.UpdateEquipmentStats();
    }
     
    public void UnEquipGear()
    {

            inventoryManager.DeselectAllSlots();

            inventoryManager.AddItem(itemName, itemSprite, itemType);

            for (int i = 0; i < equipmentSOlibrary.itemSOs.Length; i++)
            {
                if (equipmentSOlibrary.itemSOs[i].itemName == this.itemName)
                {
                    equipmentSOlibrary.itemSOs[i].UnEquipItem();
                }
            }
            PlayerManager.instance.TurnOffPreviewStats();
        PlayerManager.instance.UpdateEquipmentStats();
        EmptySlot();

    }
    public void CheckGearSlot()
    {

        if (slotInUse )
        {
            for (int i = 0; i < equipmentSOlibrary.itemSOs.Length; i++)
            {
                if (equipmentSOlibrary.itemSOs[i].itemName == this.itemName)
                {
                    equipmentSOlibrary.itemSOs[i].EquipItem();
                }
            }

            PlayerManager.instance.UpdateEquipmentStats();
        }
    }
    private void EmptySlot()
    {
        slotImage.sprite = emptySprite;
        itemName = string.Empty;
        slotInUse = false;
    }
    public void ResetEquipmentSlot()
    {
        slotImage.sprite = emptySprite;
        itemName = string.Empty;
        itemSprite = null;
        slotInUse = false;
    }
}
