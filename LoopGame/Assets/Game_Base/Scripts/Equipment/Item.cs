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
    public ItemType itemType;
    public int precioItem;
    [SerializeField] TMP_Text preciotext;
    private void Awake()
    {
        precioItem = Random.Range(20, 40) + CoinAndScore.instance.score;

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
    if (precioItem < CoinAndScore.instance.coins && GameManager.instance.slots >0)
           {
            CoinAndScore.instance.AddCoins(-precioItem);
            GameManager.instance.itemBought = true;
             GameManager.instance.itemsRemain -= 1;

            inventoryManager.AddItem(itemName, sprite, itemType);
           preciotext.text = "";
             Destroy(gameObject);
            GameManager.instance.slots -= 1;
     }
    }

}
