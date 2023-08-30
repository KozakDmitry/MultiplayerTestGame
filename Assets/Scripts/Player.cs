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
    private FixedJoystick joystickForMove, joystickForFire;
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
    private float reloadTime = 0.4f,lastFireTime = 0.0f;
    public void StartGame()
    {

    }
    public void StopGame()
    {

    }

    public void SetJoystickForFire(FixedJoystick joystick)
    {
        joystickForFire = joystick; 
    }
    public void SetJoystickForMove(FixedJoystick joystick)
    {
        joystickForMove = joystick;
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
    private void Shoot()
    {
        if (Time.time - lastFireTime > reloadTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, fireSpot.position, fireSpot.rotation);
            bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(fireSpot.up * startSpeed, ForceMode2D.Impulse);
            lastFireTime = Time.time;
        }
    }

    private void Update()
    {
        if (view.IsMine)
        {

            moveInput.x = joystickForMove.Horizontal;
            moveInput.y = joystickForMove.Vertical;
            if(joystickForFire.Direction.normalized != Vector2.zero) 
            {
                hAxis = joystickForFire.Horizontal;
                vAxis = joystickForFire.Vertical;
                zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
                Shoot();
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
