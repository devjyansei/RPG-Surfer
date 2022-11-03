using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] Movement movement;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        // ResetState();
    }

    public void ResetState()
    {
        PlayerData.Instance.health = 100;
        PlayerData.Instance.damage = 10;
        PlayerData.Instance.currentEnemy = null;
    }
    public void StopGame()
    {
        Time.timeScale = 0;
       // movement.enabled = false;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
       // movement.enabled = true;

    }
}
