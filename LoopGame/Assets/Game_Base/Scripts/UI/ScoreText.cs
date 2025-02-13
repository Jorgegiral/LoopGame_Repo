using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    void Start()
    {
        CoinAndScore.instance.scoreText = gameObject.GetComponent<TMP_Text>();
        CoinAndScore.instance.UpdateScoreCoinsUI();
    }


}
