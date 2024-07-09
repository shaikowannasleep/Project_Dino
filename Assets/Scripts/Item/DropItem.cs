using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] drop; // Array of health items

    [SerializeField]
    private float dropChance = 50f; // Chance of dropping a health item (in percentage)


    public void ItemDrop()
    {
            float randomNum = Random.Range(0f, 100f);
            if (randomNum <= dropChance)
            {
                int randomIndex = Random.Range(0, drop.Length);
                Instantiate(drop[randomIndex], transform.position, Quaternion.identity);
            }
        
    }

}
