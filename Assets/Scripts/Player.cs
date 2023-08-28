using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IStart
{
    private PhotonView view;
    [SerializeField] private float speed;
    private Vector2 moveInput, moveOutput;
    [SerializeField] private GameObject bullet;
    [SerializeField] private int health;

    public void StartGame()
    {

    }
    public void StopGame()
    {

    }

    private void Awake()
    {
        GameHelper.SubscrubeGT(this.gameObject);
        view = GetComponent<PhotonView>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void GetDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(bullet, transform.position, transform.rotation);
            }
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveOutput = moveInput.normalized*speed*Time.deltaTime;
            transform.position += (Vector3)moveOutput;
        }
    }
}
