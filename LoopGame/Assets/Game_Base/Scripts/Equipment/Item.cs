using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite sprite;
    private InventoryManager inventoryManager;
    [TextArea]
    [SerializeField] private string itemDescription;
    public ItemType itemType;
    void Start()
    {
        inventoryManager = GameObject.Find("GearUI").GetComponent<InventoryManager>();
    }

    private void OnMouseDown()
    {
        inventoryManager.AddItem(itemName, sprite,itemDescription,itemType);
        Destroy(gameObject);
    }

}
