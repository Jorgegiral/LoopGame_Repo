using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private void Update()
    {
        CoinAndScore.instance.scoreText = gameObject.GetComponent<TMP_Text>();

    }

}
