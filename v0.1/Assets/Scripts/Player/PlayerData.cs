using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public EnemyData currentEnemy;

    public static PlayerData Instance;

    public int health = 100;
    public int damage = 10;
    public int experience;

    private void Awake()
    {
        Instance = this;
    }
    
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            if (currentEnemy != null)
            {
                currentEnemy.GetComponent<EnemyData>().TakeDamage(damage);
            }
        }
    }
    void Die()
    {
        GameManager.Instance.ResetState();
        Destroy(gameObject);
    }
}

