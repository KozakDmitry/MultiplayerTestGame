using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour,IStart
{
    private PhotonView view;
    [SerializeField] private float speed;
    [SerializeField] private FixedJoystick joystickForMove, joystickForFire;
    private Vector2 moveInput;
    
    [SerializeField] private Slider slider;
   
  

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform fireSpot;
    [SerializeField] private float startSpeed;
    [SerializeField] private int maxHealth;
    private Rigidbody2D bulletRb;
    private float hAxis, vAxis, zAxis;
    private int currentHealth;
    private Rigidbody2D rb;
    
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
        rb = GetComponent<Rigidbody2D>();
        slider.maxValue = maxHealth;
        currentHealth = maxHealth;
    }


    void Start()
    {
       
    }
    public void GetDamage(int dmg)
    {
        currentHealth -= dmg;
        slider.value = currentHealth;
        if (currentHealth <= 0)
        {
            GameHelper.EndGame();
            
        }
    }

    private void Update()
    {
        if (view.IsMine)
        {

            moveInput.x = joystickForMove.Horizontal;
            moveInput.y = joystickForMove.Vertical;
            Debug.Log(moveInput.ToString());
            if(joystickForFire.Direction.normalized != Vector2.zero) 
            {
                hAxis = joystickForFire.Horizontal;
                vAxis = joystickForFire.Vertical;
                zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
                GameObject bullet = Instantiate(bulletPrefab, fireSpot.position, fireSpot.rotation);
                bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.AddForce(fireSpot.up * startSpeed, ForceMode2D.Impulse);
            }
            else
            {
                hAxis = moveInput.x;
                vAxis = moveInput.y;
                zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
            }
            
        }
        
    }
    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            rb.MovePosition(rb.position + moveInput.normalized * speed * Time.fixedDeltaTime);        
        }
    }
}
