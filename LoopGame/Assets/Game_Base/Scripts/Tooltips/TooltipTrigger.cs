using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Variables
    public string header;
    [MultilineAttribute()]
    public string leftcontent;
    #endregion
    #region Functions
    private void Update()
    {
        if(GameManager.instance.itemBought == true || GameManager.instance.itemsRemain == 0)
        {
            TooltipManager.Hide();
            GameManager.instance.itemBought = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
            TooltipManager.Show(leftcontent, header);
     
    }
    public void OnPointerExit(PointerEventData eventData) { TooltipManager.Hide(); }
    
    #endregion
}
