using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    public static Market Instance;

    GameObject buffHolder;
    [SerializeField] List<GameObject> buffList = new List<GameObject>();
    [SerializeField] List<GameObject> buffHolderList = new List<GameObject>();

    int buffAmount = 3;

    public GameObject marketPanel;
    public int attackBuffPrice;
    public int healthBuffPrice;
    public int extraMoneyAmount;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.StopGame();
        this.gameObject.SetActive(false);

        if (other.gameObject.CompareTag("Player"))
        {
            OpenMarket();
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        buffHolder = GameObject.Find("BuffHolder");
    }
    private void Start()
    {
        SetBuffs();       
    }
    public void SelectHealth(int amount)
    {
        PlayerData.Instance.IncreaseHealth(amount);
        Bank.Instance.DecraseMoney(healthBuffPrice);
        UiManager.Instance.UpdatePlayerHealthText();

        // Set health equal to Max health
        if (PlayerData.Instance.health > PlayerData.Instance.maxHealth)
        {
            PlayerData.Instance.health = PlayerData.Instance.maxHealth;
        }

        CloseMarket();
    }
    public void SelectAttack(int amount)
    {
        PlayerData.Instance.IncreaseDamage(amount);       
        Bank.Instance.DecraseMoney(attackBuffPrice);
        CloseMarket();

    }
    public void SelectMoney()
    {
        Bank.Instance.IncreaseMoney(extraMoneyAmount);
        CloseMarket();

    }
    public void OpenMarket()
    {
        GameManager.Instance.StopGame();
        marketPanel.SetActive(true);
        TransferBuffs();
    }
    void CloseMarket()
    {
        GameManager.Instance.ContinueGame();
        marketPanel.SetActive(false);
        BackTransferBuffs();

        //random deðiþtirme hakki koyulabilir.  butona backtransfer ve transfer iþlemlerini sirayla yapan bir fonksiyon ekle.
    }


    // ------------------------ BUFF LISTING ---------------------------

    void SetBuffs()
    {
        for (int i = 0; i < buffHolder.transform.childCount; i++)
        {
            buffHolderList.Add(buffHolder.transform.GetChild(i).gameObject);
        }
    }
    void TransferBuffs()
    {
        // bufflari random bir sekilde buffliste yerlestir
        for (int i = 0; i < buffAmount; i++)
        {
            int childIndex = Random.Range(0, buffHolderList.Count);           
            buffList.Add(buffHolderList[childIndex]);
            buffHolderList.Remove(buffHolderList[childIndex]);
        }
        // yerlestirilen bufflarin parentlarini canvas icin ayarla
        foreach (GameObject buff in buffList)
        {
            buff.transform.SetParent(marketPanel.transform);     
        }
    }
    
    void BackTransferBuffs()
    {
        // bufflari listeden ve marketten cikart
        int temp = buffList.Count-1; // bir degiskene atamazsak asla 3 elemani listeden cikaramiyoruz.
        for (int i = temp; i >= 0;i--)
        {
            buffList[i].transform.SetParent(buffHolder.transform);
            buffList.Remove(buffList[i]);                      
        }
        // bufflarý bufftutucuya geri koy
        for (int i = 2; i < buffHolder.transform.childCount; i++)
        {
            buffHolderList.Add(buffHolder.transform.GetChild(i).gameObject);
        }
       
    }
    public void ReRollBuffs()
    {
        BackTransferBuffs();
        TransferBuffs();        
    }
}
