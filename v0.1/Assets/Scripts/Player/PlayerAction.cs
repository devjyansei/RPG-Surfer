using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAction : MonoBehaviour
{
    public static PlayerAction Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {                           
            EnemyData tempEnemy = other.gameObject.GetComponent<EnemyData>();
            PlayerData.Instance.currentEnemy = tempEnemy;

            tempEnemy.TakeDamage(PlayerData.Instance.damage);
           // tempEnemy.GetComponentInChildren<TextMeshPro>().text = "Health : " + tempEnemy.health;        
        }
    }
   
}
