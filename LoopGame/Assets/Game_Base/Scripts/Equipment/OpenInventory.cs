using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class OpenInventory : MonoBehaviour//, IPointerClickHandler
{
    [SerializeField] InventoryManager inventoryManager;
    private PlayerInput playerInput;

    void Start()
    {
        inventoryManager = GameObject.Find("GearUI").GetComponent<InventoryManager>();
        playerInput = FindObjectOfType<PlayerInput>();
    }
    /*private void Update()
    {
        inventoryManager = GameObject.Find("GearUI").GetComponent<InventoryManager>();

    }public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

    }*/
    /*public void OnLeftClick()
    {
        inventoryManager.HandleInventory();
    }*/
    public void Handleinventory(InputAction.CallbackContext context)
    {
        inventoryManager.HandleInventory();
    }
}
