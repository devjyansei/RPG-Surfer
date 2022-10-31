using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public PlayerData currentPlayer;

    public int health = 100;
    public int damage = 1;
    public int experienceReward = 10;
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
            Destroy(gameObject);
        }
        else
        {
            if ( currentPlayer != null)
            {
                PlayerData.Instance.TakeDamage(damage);
                Debug.Log("player health " + currentPlayer.health);

            }
        }
    }

}
