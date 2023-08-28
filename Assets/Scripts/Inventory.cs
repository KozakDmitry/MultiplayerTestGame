using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int coinCount=0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Coin")
        {
            coinCount++;
            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
