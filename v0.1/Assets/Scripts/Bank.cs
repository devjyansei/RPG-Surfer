using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{   //stores all money data

    public static Bank Instance;
    public static int goldAmount { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {Instance = this;}
        else
        {Destroy(gameObject);}
    }

    private void Start()
    {
        goldAmount = 50;
    }
    public void IncreaseMoney(int amount)
    {
        goldAmount += amount;
    }
    public void DecraseMoney(int amount)
    {
        goldAmount -= amount;
    }
    
}
