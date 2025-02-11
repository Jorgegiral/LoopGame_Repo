using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    private Transform entrycontainer;
    private Transform entrytemplate;
    private void Awake()
    {
        entrycontainer = transform.Find("HighscoreEntryContainer");
        entrytemplate = entrycontainer.Find("HighscoreTemplate");
        entrytemplate.gameObject.SetActive(false);

        float templateHeight = 20f;
        for (int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entrytemplate, entrycontainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
        }
    }
}
