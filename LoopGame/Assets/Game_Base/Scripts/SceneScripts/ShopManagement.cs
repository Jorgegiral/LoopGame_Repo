using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManagement : MonoBehaviour
{
    [SerializeField] GameObject[] spots;
    [SerializeField] GameObject[] items;
    [SerializeField] int spotRandomizer;
    [SerializeField] int itemslotRandomizer;
    [SerializeField] int spotSelector;

    void Start()
    {
        spotRandomizer = Random.Range(1, 101);
        itemslotRandomizer = Random.Range(1, 5);
        spotSelector = Random.Range(1, 5);
        if (spotRandomizer <= 35)
        {
            ActivateRandomSpots(1);

            //  spots[spotSelector].SetActive(true);
        }
        else if (spotRandomizer <= 60)
        {
            ActivateRandomSpots(2);

            // spots[spotSelector].SetActive(true);

        }
        else if (spotRandomizer <= 90)
        {
            ActivateRandomSpots(3);

            //  items[spotSelector].SetActive(true);
        }
        else
        {
            ActivateRandomSpots(4);

            /*  for (int i = 0; i < spots.Length; i++)
              {
                  spots[i].SetActive(true);
              }
            */
        }
    }
    void ActivateRandomSpots(int amount)
    {
        if (spots.Length < amount) amount = spots.Length; // Evita errores si hay pocos spots

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

}
