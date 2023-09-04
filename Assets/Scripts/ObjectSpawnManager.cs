using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnManager : MonoBehaviour, IStart
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Renderer playableCollider;
    private Vector3 minPoint, maxPoint;
    private Vector3 offset = new Vector3(0, 0, -1.5f);
    private void Start()
    {
        GameHelper.SubscrubeGT(this.gameObject);
        maxPoint = playableCollider.bounds.max;
        minPoint = playableCollider.bounds.min;
    }
    public void StartGame()
    {
        InvokeRepeating(nameof(SpawnCoins), 1f, 2f);
        
    }

    private void SpawnCoins()
    {
        
        Vector3 availablePos = new Vector3(Random.Range(minPoint.x, maxPoint.x), Random.Range(minPoint.y, maxPoint.y), 0);
        Instantiate(coinPrefab,availablePos+offset,Quaternion.identity);
    }
    

    public void StopGame()
    {
        CancelInvoke(nameof(SpawnCoins));
    }
}
