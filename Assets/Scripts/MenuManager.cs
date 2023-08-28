using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField joinInput, createInput;

    [SerializeField]
    private Transform content;
    [SerializeField]
    private RoomListing roomListing;
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text, new RoomOptions { MaxPlayers = 2 }); 
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo room in roomList) 
        {
            RoomListing listing = Instantiate(roomListing, content);
            if(listing != null) 
            {
                listing.SetRoomInfo(room); 
            }
        }
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
