using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManagement : MonoBehaviour
{
    [SerializeField] GameObject[] spots;
    [SerializeField] int spotRandomizer;
    [SerializeField] int spotSelector;
    
    

    void Start()
    {
        GameManager.instance.inShop = true;
        GameManager.instance.dailyVisit = false;
        CoinAndScore.instance.AddCoins(0);
        CoinAndScore.instance.AddScore(0);
        spotRandomizer = Random.Range(1, 101);
        spotSelector = Random.Range(1, 5);
        if (spotRandomizer <= 35)
        {
            GameManager.instance.itemsRemain += 1;
            ActivateRandomSpots(1);

        }
        else if (spotRandomizer <= 60)
        {
            GameManager.instance.itemsRemain += 2;

            ActivateRandomSpots(2);


        }
        else if (spotRandomizer <= 90)
        {
            GameManager.instance.itemsRemain += 3;

            ActivateRandomSpots(3);

        }
        else
        {
            GameManager.instance.itemsRemain += 4;

            ActivateRandomSpots(4);


        }
    }
    void ActivateRandomSpots(int amount)
    {
        if (spots.Length < amount) amount = spots.Length; 

        List<int> availableIndexes = new List<int>();
        for (int i = 0; i < spots.Length; i++)
        {
            availableIndexes.Add(i);
        }

        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, availableIndexes.Count);
            spots[availableIndexes[randomIndex]].SetActive(true);
            availableIndexes.RemoveAt(randomIndex);
        }
    }
    public void GoToVillage()
    {
        GameManager.instance.inShop = false;
        GameManager.instance.itemsRemain = 0;
        SceneManager.LoadScene(1);

    }

}
