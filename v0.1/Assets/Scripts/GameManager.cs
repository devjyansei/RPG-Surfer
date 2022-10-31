using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        PlayerData.Instance.health = 100;
        PlayerData.Instance.damage = 10;
        PlayerData.Instance.experience = 0;
        PlayerData.Instance.currentEnemy = null;
    }
}
