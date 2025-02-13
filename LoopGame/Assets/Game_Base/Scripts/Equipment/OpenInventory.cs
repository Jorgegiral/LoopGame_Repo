using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenInventory : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("GearUI").GetComponent<InventoryManager>();

    }
    private void Update()
    {
        inventoryManager = GameObject.Find("GearUI").GetComponent<InventoryManager>();

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

    }
    public void OnLeftClick()
    {
        inventoryManager.HandleInventory();
    }
}
