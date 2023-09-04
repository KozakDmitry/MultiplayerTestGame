using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int coinCount=0;
    private TextMeshProUGUI coinsNum;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            AddMoney();

            Destroy(other.gameObject);
        }
    }
 
    private void AddMoney(int i = 1) 
    {
        coinCount += i;
        coinsNum.text = coinCount.ToString();
    }

    public void SetMoneyUI(TextMeshProUGUI coinsText)
    {
        coinsNum = coinsText;
        coinsNum.text = coinCount.ToString();
    }

}
