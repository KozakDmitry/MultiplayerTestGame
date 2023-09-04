using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] FixedJoystick joyStickForFire, joyStickForMove;
    [SerializeField] GameObject slider;
    [SerializeField] TextMeshProUGUI moneyText;


    void Start()
    {
        GameManager.PlayerCreated += SetStartUI;
    }
    
    private void SetStartUI(Transform player)
    {
        Player playerComp = player.GetComponent<Player>(); 
        playerComp.SetJoystickForFire(joyStickForFire);
        playerComp.SetJoystickForMove(joyStickForMove);
        GameObject sl = Instantiate(slider, this.transform);
        playerComp.setHpBar(sl.GetComponent<Slider>());
        player.GetComponent<Inventory>().SetMoneyUI(moneyText);
    }

}
