using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
                    p.GetComponentInChildren<HpBar>().SetCamera(this.transform);
                }

            }
        }
        if(player!= null)
        {
            transform.position = player.position + Vector3.forward * -10f;
        }
    }


    private void FixedUpdate()
    {
        Vector3 targetPosition = player.position + Vector3.forward * -10f;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, 1f);
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.position = smoothedPosition;
    }
}
