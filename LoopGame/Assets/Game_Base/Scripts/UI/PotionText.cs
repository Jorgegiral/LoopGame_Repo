using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionText : MonoBehaviour
{
    

    private void Update()
    {
        PlayerManager.instance.potionText = gameObject.GetComponent<TMP_Text>();

    }
}
