using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        player.GetComponent<Player>().SetJoystickForFire(joyStickForFire);
        player.GetComponent<Player>().SetJoystickForMove(joyStickForMove);
        GameObject sl = Instantiate(slider, this.transform);
        player.GetComponent<Inventory>().SetMoneyUI(moneyText);
    }

}
