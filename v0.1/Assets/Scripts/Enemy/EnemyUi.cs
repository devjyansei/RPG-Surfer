using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyUi : MonoBehaviour
{
    public TextMeshPro enemyTmp;

    EnemyData enemyData;
    void Awake()
    {
         enemyData = GetComponent<EnemyData>();        
    }

    void Update()
    {
        enemyTmp.text = "Health : " + enemyData.health;
    }
}
