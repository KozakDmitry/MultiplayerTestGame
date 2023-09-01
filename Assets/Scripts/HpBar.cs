using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    private Transform player;
    [SerializeField] private Vector3 offset = new Vector3(0,1f,0);
    private void Awake()
    {
        GameManager.PlayerCreated += SetPlayer;
    }
    public void SetPlayer(Transform player)
    {
        this.player = player;
    }

    private void LateUpdate()
    {
        if (player != null) 
        {
            transform.position = player.position+offset;
        }
    }

}
