using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [SerializeField] PlayerData playerData;
    public TextMeshProUGUI goldAmountText;
    [SerializeField] TextMeshPro playerHealthTmp;

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
        goldAmountText.text = "Gold : " + Bank.Instance.GoldAmount;
    }

    public void UpdatePlayerHealthText()
    {
        playerHealthTmp.text = "HP : " + playerData.health;
    }
}
