using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchGearUI : MonoBehaviour
{
    InventoryManager inventoryManager;
    private void Awake()
    {
        inventoryManager = GameObject.Find("GearUI").GetComponent<InventoryManager>();
        
    }

    private void OnMouseDown()
    {
        inventoryManager.HandleInventory();
    }
}
