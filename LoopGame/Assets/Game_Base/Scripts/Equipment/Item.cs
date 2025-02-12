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
    public int precioItem;
    void Start()
    {
        precioItem = Random.Range(20,40)+GameManager.instance.score;
        inventoryManager = GameObject.Find("GearUI").GetComponent<InventoryManager>();
    }

    private void OnMouseDown()
    {
        if (precioItem < GameManager.instance.coins)
        {
            GameManager.instance.AddCoins(-precioItem);
            inventoryManager.AddItem(itemName, sprite, itemDescription, itemType);
            Destroy(gameObject);
        }
    }

}
