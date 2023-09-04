using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameHelper 
{
    public delegate void GameStart();
    public static event GameStart NotEnoughtPlayers = delegate { };
    public static event GameStart GameReady = delegate { };

    private static bool isEnoughPeople = false;

    public static void SubscrubeGT(GameObject gameObject)
    {
        IStart iStart = gameObject.GetComponent<IStart>();
        NotEnoughtPlayers += iStart.StopGame;
        GameReady += iStart.StartGame;
    }

    public static void EndGame()
    {
        
    }


    public static bool IsEnoughPeople()
    {
        return isEnoughPeople;
    }
    public static void CheckConnectedPeople()
    {
        if(PhotonNetwork.CountOfPlayers == 1) 
        {
            isEnoughPeople = true;
            GameReady();   
            
        }
        else
        {
            isEnoughPeople =false;
            NotEnoughtPlayers();
        }
    }
}
