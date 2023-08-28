using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float minX, minY, maxX, maxY;
    void Start()
    {
        Vector2 spawnPos = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
        PhotonNetwork.Instantiate(player.name, spawnPos, Quaternion.identity);
    }


}
