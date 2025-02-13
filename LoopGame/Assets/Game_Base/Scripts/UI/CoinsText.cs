using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    void Start()
    {
        CoinAndScore.instance.coinsText = gameObject.GetComponent<TMP_Text>();
    }

}
