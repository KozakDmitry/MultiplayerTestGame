using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnManager : MonoBehaviour, IStart
{
    [SerializeField] private GameObject coinPrefab;

    public void StartGame()
    {
        InvokeRepeating(nameof(SpawnCoins), 1f, 2f);
        
    }

    private void SpawnCoins()
    {
        Instantiate(coinPrefab);
    }
    

    public void StopGame()
    {

    }
}
