using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.scoreText = gameObject.GetComponent<TMP_Text>();
        GameManager.instance.UpdateScoreCoinsUI();
    }


}
