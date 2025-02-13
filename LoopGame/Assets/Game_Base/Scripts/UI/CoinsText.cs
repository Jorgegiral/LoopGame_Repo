using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsText : MonoBehaviour
{

    private void Update()
    {
        CoinAndScore.instance.coinsText = gameObject.GetComponent<TMP_Text>();

    }

}
