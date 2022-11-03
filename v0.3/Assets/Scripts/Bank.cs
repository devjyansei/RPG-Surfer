using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{   //stores all money data

    public static Bank Instance;
    private static int goldAmount;
    public int GoldAmount
    {
        get { return goldAmount; }
        set { goldAmount = value; }
    }
    private void Awake()
    {
        if (Instance == null)
        {Instance = this;}
        else
        {Destroy(gameObject);}
    }

    public void IncreaseMoney(int amount)
    {
        GoldAmount += amount;
        UiManager.Instance.goldAmountText.text = "Gold : " + GoldAmount;
    }
    public void DecraseMoney(int amount)
    {
        GoldAmount -= amount;
        UiManager.Instance.goldAmountText.text = "Gold : " + GoldAmount;
    }
}
