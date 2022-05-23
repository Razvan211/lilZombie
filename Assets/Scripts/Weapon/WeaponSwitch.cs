using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public PlayerInput player;
    public GameObject shotgun;
    public GameObject pistol;

    void Awake()
    {
        player = new PlayerInput();
        player.Alive.Pistol.performed += ctx => Pistol();
        player.Alive.Shotgun.performed += ctx => Shotgun();

    }

    private void OnEnable()
    {
        player.Alive.Enable();
    }
    private void OnDisable()
    {
        player.Alive.Disable();
    }
    void Start()
    {

        pistol.SetActive(false);
        shotgun.SetActive(true);
    }

    private void Shotgun()
    {
        pistol.SetActive(false);
        shotgun.SetActive(true);
        
        Debug.Log("Shotgun");
       
    }
    private void Pistol()
    {
        shotgun.SetActive(false);
        pistol.SetActive(true);
        
        Debug.Log("Pistol");
    }

}
