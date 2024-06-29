using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{

    public Image buttonImage;
    public Text amountText;
    public int buttonValue;

  

    public void Press()
    {
        if (buttonValue >= 0 && buttonValue < GameManager.instance.itemsHeld.Length)
        {
            if (!string.IsNullOrEmpty(GameManager.instance.itemsHeld[buttonValue]))
            {
                GameMenu.instance.SelectItem(GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[buttonValue]));
            }
        }

        if (Shop.instance != null && Shop.instance.shopMenu != null && Shop.instance.shopMenu.activeInHierarchy)
        {
            if (Shop.instance.buyMenu != null && Shop.instance.buyMenu.activeInHierarchy)
            {
                if (GameManager.instance != null && Shop.instance.itemsForSale != null && Shop.instance.itemsForSale.Length > buttonValue)
                {
                    Shop.instance.SelectBuyItem(GameManager.instance.GetItemDetails(Shop.instance.itemsForSale[buttonValue]));
                }
                else
                {
                    Debug.LogWarning("One or more required objects or variables are null or out of range.");
                }
            }

            if (Shop.instance.sellMenu != null && Shop.instance.sellMenu.activeInHierarchy)
            {
                if (GameManager.instance != null && GameManager.instance.itemsHeld != null && GameManager.instance.itemsHeld.Length > buttonValue)
                {
                    Shop.instance.SelectSellItem(GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[buttonValue]));
                }
                else
                {
                    Debug.LogWarning("One or more required objects or variables are null or out of range.");
                }
            }
        }
        else
        {
            Debug.LogWarning("Shop.instance or Shop.instance.shopMenu is null.");
        }
    }
}
