using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public PlayerData currentPlayer;

    public int health;
    public int damage;
    public int experienceReward;
    private void Start()
    {
        currentPlayer = null;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            currentPlayer.GetComponent<Movement>().enabled = true;
            ExperienceManager.Instance.GainExperience(experienceReward);
            UiManager.Instance.UpdatePlayerHealthText();
            Destroy(gameObject);
        }
        else
        {
            if ( currentPlayer != null)
            {
                PlayerData.Instance.TakeDamage(damage);                     
            }
        }
    }

}
