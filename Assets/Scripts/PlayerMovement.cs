using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView view;
    [SerializeField] private float speed;
    private Vector2 moveInput, moveOutput;


    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) ;
            moveOutput = moveInput.normalized*speed*Time.deltaTime;
            transform.position += (Vector3)moveOutput;
        }
    }
}
