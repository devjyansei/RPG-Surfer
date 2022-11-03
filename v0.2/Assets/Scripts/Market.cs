using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
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
            marketPanel.SetActive(true);
            Time.timeScale = 0f;
        }
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

        OnBuy();

    }
    public void SelectAttack(int amount)
    {
        PlayerData.Instance.IncreaseDamage(amount);       
        Bank.Instance.DecraseMoney(attackBuffPrice);
        OnBuy();

    }
    public void SelectMoney()
    {
        Bank.Instance.IncreaseMoney(extraMoneyAmount);
        OnBuy();

    }
    void OnBuy()
    {
        GameManager.Instance.ContinueGame();
        marketPanel.SetActive(false);
    }
}
