using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public EnemyData currentEnemy;

    public static PlayerData Instance;

    public int maxHealth;
    public int health;
    public int damage;

    public int range;
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        maxHealth = 150;
        maxHealth = Mathf.Clamp(maxHealth, 0, 150);
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
    public void IncreaseHealth(int amount)
    {
        health += amount;
    }
    public void IncreaseDamage(int amount)
    {
        damage += amount;
    }
}

