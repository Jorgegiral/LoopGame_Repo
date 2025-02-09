using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotionText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.instance.potionText = gameObject.GetComponent<TMP_Text>();

    }


}
