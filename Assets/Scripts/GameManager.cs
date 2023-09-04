using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks,IStart 
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float minX, minY, maxX, maxY;

    public delegate void PlayerFoundEventHandler(Transform player);
    public static event PlayerFoundEventHandler PlayerCreated = delegate { };

    void Awake()
    {
        
        Vector2 spawnPos = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
        player = PhotonNetwork.Instantiate(player.name, spawnPos, Quaternion.identity);
        
    }
    private void Start()
    {
        GameHelper.CheckConnectedPeople();
        if (player.GetComponent<PhotonView>().IsMine)
        {
            PlayerCreated(player.transform);
        }
    }
    public void StartGame()
    {
        player.GetComponent<Player>().enabled = true;
    }

    public void StopGame()
    {
        PlayerUnactive(player.transform);
    }
    
    private void PlayerUnactive(Transform player)
    {
        player.gameObject.GetComponent<Player>().enabled = false;
    }
    
    public override void OnJoinedRoom()
    {
        GameHelper.CheckConnectedPeople();
    }

    public override void OnLeftRoom()
    {
        GameHelper.CheckConnectedPeople();
    }
}
