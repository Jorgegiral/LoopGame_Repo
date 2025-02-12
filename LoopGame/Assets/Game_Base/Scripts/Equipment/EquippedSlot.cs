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
    [SerializeField] private TMP_Text slotName;

    //slot data
    [SerializeField] private ItemType itemType = new ItemType();
    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;

    private bool slotInUse;
    public GameObject selectedShader;
    public bool thisItemSelected;
    [SerializeField] Sprite emptySprite;
    private InventoryManager inventoryManager;
    private EquipmentSOlibrary equipmentSOlibrary;
    private ItemSO[] itemSOs;

    private void Start()
    {
        emptySprite = null;
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
            EmptySlot();
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(false);
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
    public void EquipGear(Sprite itemsprite, string itemName, string itemDescription)
    {
        if (slotInUse)
        {
            UnEquipGear();
        }
        this.itemSprite = itemsprite;
        slotImage.sprite = this.itemSprite;
        slotName.enabled = false;

        this.itemName = itemName;
        this.itemDescription = itemDescription;

        for (int i = 0; i < equipmentSOlibrary.itemSOs.Length; i++)
        {
            if (equipmentSOlibrary.itemSOs[i].itemName == this.itemName)
            {
                equipmentSOlibrary.itemSOs[i].EquipItem();
        
            }
        }
    }
     
    public void UnEquipGear()
    {
        inventoryManager.DeselectAllSlots();
        inventoryManager.AddItem(itemName,itemSprite,itemDescription,itemType);
        // UpdateSlotImage
        this.itemSprite=emptySprite;
        slotImage.sprite=this.emptySprite;
        slotName.enabled = true;
        for (int i = 0; i < equipmentSOlibrary.itemSOs.Length; i++)
        {
            if (equipmentSOlibrary.itemSOs[i].itemName == this.itemName)
            {
                equipmentSOlibrary.itemSOs[i].UnEquipItem();
            }
        }
        PlayerManager.instance.TurnOffPreviewStats();
    }
    public void CheckGearSlot()
    {
        if (PlayerManager.instance.statsChanged)
        {
            return;
        }else
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
            PlayerManager.instance.statsChanged = false;
        }
    }
    private void EmptySlot()
    {
        slotImage.sprite = emptySprite;
        itemName = string.Empty;
        itemDescription = string.Empty;
        slotInUse = false;
        slotName.enabled = true;  
    }
}
