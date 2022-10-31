using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Bank.Instance.IncreaseMoney(value);
            UiManager.Instance.UpdateGoldAmount();
            Destroy(gameObject);
            Debug.Log(Bank.goldAmount);
        }
    }
}
