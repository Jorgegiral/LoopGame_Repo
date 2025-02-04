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
    public string raritycontent;
    #endregion
    #region Functions
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.Show(leftcontent,raritycontent,header);
    }
    public void OnPointerExit(PointerEventData eventData) { TooltipManager.Hide(); }
    #endregion
}
