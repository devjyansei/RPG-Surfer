using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    Movement movement;
    EnemyData enemyData;

    private void Awake()
    {
        movement = FindObjectOfType<Movement>();
        enemyData = GetComponent<EnemyData>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyData.currentPlayer = other.gameObject.GetComponent<PlayerData>();
            movement.enabled = false;
            PlayerData.Instance.TakeDamage(enemyData.damage);                       
        }        
    }
    
    //if hp == 0 movement enable
}
