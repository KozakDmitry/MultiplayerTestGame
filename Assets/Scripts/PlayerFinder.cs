using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    private Transform player;
    [SerializeField] FixedJoystick joyStickForFire, joyStickForMove;
    [SerializeField] GameObject slider;

    public delegate void PlayerFoundEventHandler(Transform player);
    public static event PlayerFoundEventHandler PlayerFound = delegate { };

    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length != 0)
        {
            foreach (GameObject p in players)
            {
                if (p.GetComponent<PhotonView>().IsMine)
                {
                    player = p.transform;
                    p.GetComponent<Player>().SetJoystickForFire(joyStickForFire);
                    p.GetComponent<Player>().SetJoystickForMove(joyStickForMove);
                    
                }

            }
        }
        if (player != null)
        {
            GameObject sl = Instantiate(slider, this.transform);
            PlayerFound(player);
        }
    }

}
