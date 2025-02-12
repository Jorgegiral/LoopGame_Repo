using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Color = UnityEngine.Color; 

[ExecuteInEditMode]
public class Tooltip : MonoBehaviour
{
    #region Variables
    [Header("Content Variables")]
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI leftContentField;
    [Header("Resize Variables")]
    public LayoutElement layoutElement;
    public int characterWrapLimit;
    public RectTransform rectTransform;
    [Header("Color Variables")]
    private Color colorSpecial, colorRare, colorEpic;

    


    #endregion
    #region UnityFunctions
    private void Awake()
    {
        colorEpic = Color.red;
        colorRare = Color.blue;
        colorSpecial = Color.yellow;
      
        rectTransform = GetComponent<RectTransform>();
        headerField.enableVertexGradient = true;
    }
    private void Update()
    {
        var position = Input.mousePosition;
        var normalizedPosition = new Vector2(position.x / Screen.width, position.y / Screen.height);
        var pivot = CalculatePivot(normalizedPosition);
        rectTransform.pivot = pivot;
        transform.position = position;
        if (GameManager.instance.itemsRemain == 0)
        {
            gameObject.SetActive(false);    
        }

    }

    #endregion
    #region Functions
    private Vector2 CalculatePivot(Vector2 normalizedPosition)
    {
        var pivotTopLeft = new Vector2(-0.05f, 1.05f);
        var pivotTopRight = new Vector2(1.05f, 1.05f);
        var pivotBottomLeft = new Vector2(-0.05f, -0.05f);
        var pivotBottomRight = new Vector2(1.05f, -0.05f);

        if (normalizedPosition.x < 0.5f && normalizedPosition.y >= 0.5f)
        {
            return pivotTopLeft;
        }
        else if (normalizedPosition.x > 0.5f && normalizedPosition.y >= 0.5f)
        {
            return pivotTopRight;
        }
        else if (normalizedPosition.x <= 0.5f && normalizedPosition.y < 0.5f)
        {
            return pivotBottomLeft;
        }
        else
        {
            return pivotBottomRight;
        }
    }
    public void SetText(string leftContent, string header )
    {

            
            headerField.gameObject.SetActive(true);
            headerField.text = header;
           leftContentField.text = leftContent;
    }
    
    #endregion
}
