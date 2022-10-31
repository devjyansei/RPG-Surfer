using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    public TextMeshProUGUI goldAmountText;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }   
    }

    private void Start()
    {
        UpdateGoldAmount();
    }
    public void UpdateGoldAmount()
    {
        goldAmountText.text = "Gold : " + Bank.goldAmount;
    }
}
