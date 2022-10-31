using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUi : MonoBehaviour
{
    public TextMeshPro playerHealthTmp;

    PlayerData playerData;
    private void Awake()
    {
        playerData = GetComponent<PlayerData>();
    }

    void Update()
    {
        playerHealthTmp.text = "Health : " + playerData.health;
    }
}
