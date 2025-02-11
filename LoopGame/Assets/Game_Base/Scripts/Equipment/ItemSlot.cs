using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //Item data
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;

    //Item slot
    [SerializeField] private Image itemImage;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddItem(string itemname, Sprite itemSprite)
    {
        this.itemName = itemname;
        this.itemSprite = itemSprite;
        isFull = true;
        itemImage.sprite = itemSprite;
    }
}
