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
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.Show(leftcontent,header);
    }
    public void OnPointerExit(PointerEventData eventData) { TooltipManager.Hide(); }
    #endregion
}
