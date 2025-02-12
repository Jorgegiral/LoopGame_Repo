using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite sprite;
    private InventoryManager inventoryManager;
    [TextArea]
    [SerializeField] private string itemDescription;
    public ItemType itemType;
    public int precioItem;
    [SerializeField] TMP_Text preciotext;

    private void Awake()
    {
        precioItem = Random.Range(20, 40) + GameManager.instance.score;

    }
    void Start()
    {
        preciotext.text = precioItem.ToString();
        inventoryManager = GameObject.Find("GearUI").GetComponent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }
    private void OnLeftClick()
    {
   //     if (precioItem < GameManager.instance.coins)
   //     {
            GameManager.instance.AddCoins(-precioItem);
            inventoryManager.AddItem(itemName, sprite, itemDescription, itemType);
        preciotext.text = "";

        Destroy(gameObject);
   //     }
    }

}
