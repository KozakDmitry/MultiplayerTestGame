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
    private Vector2 moveInput, moveOutput;
    private Rigidbody2D rb;
    [SerializeField] private GameObject bullet;
    [SerializeField] private int maxHealth;
    private int currentHealth;
    [SerializeField] private Slider slider;
    private Camera cam;
    private Vector2 mousePosition, lookDirection;

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
        cam = GetComponentInChildren<Camera>();
        currentHealth = maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void GetDamage(int dmg)
    {
        currentHealth -= dmg;
        slider.value = currentHealth/maxHealth;
        if (currentHealth <= 0)
        {
            Destroy(bullet);
        }
    }

    void Update()
    {
        if (view.IsMine)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(bullet, transform.position, transform.rotation);
            }
            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveOutput = moveInput.normalized*speed*Time.deltaTime;
            transform.position += (Vector3)moveOutput;
        }
    }
    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            lookDirection = mousePosition - rb.position;
            rb.rotation =  Mathf.Atan2(lookDirection.y, lookDirection.x)*Mathf.Rad2Deg - 90f;
           
        }
    }
}
