using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField] FixedJoystick joyStickForFire, joyStickForMove;

    private void Start()
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
        if(player!= null)
        {
            transform.position = player.position + Vector3.up * 10f;
        }
    }


    private void FixedUpdate()
    {
        Vector3 targetPosition = player.position + Vector3.up * 10f;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, 1f);
        transform.position = smoothedPosition;
    }
}
