using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    #region Variables
    private static TooltipManager instance;
    public Tooltip  tooltip;
    #endregion
    #region UnityFunctions
    public void Awake()
    {
        instance = this;
    }
    #endregion
    #region Functions
    public static void Show(string leftContent, string rarityContent, string header = "")
    {
        instance.tooltip.SetText(leftContent, rarityContent, header);
        instance.tooltip.gameObject.SetActive(true);
    }
    public static void Hide() 
    {
        instance.tooltip.gameObject.SetActive(false);
    }
#endregion
}
