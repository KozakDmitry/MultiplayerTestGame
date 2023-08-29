using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public void SetRoomInfo(RoomInfo roomInfo)
    {
       
        text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
     
     
    }
 
}
