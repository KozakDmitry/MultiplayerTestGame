using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private void Awake()
    {
        GameManager.PlayerCreated += SetPlayer;
    }

    public void SetPlayer(Transform player)
    {
        this.player = player;
        transform.position = player.position + Vector3.forward * -20f;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = player.position + Vector3.forward * -20;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, 1f);
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.position = smoothedPosition;
    }
}
