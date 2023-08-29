using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
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
  
    public override void OnConnectedToMaster()
    {
        GameHelper.CheckConnectedPeople();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        GameHelper.CheckConnectedPeople();
    }
}
