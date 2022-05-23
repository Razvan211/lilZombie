using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30;
    public PlayerInput player;
   
    

    public void Awake()
    {
        player = new PlayerInput();
        player.Alive.Shoot.performed += ctx => Shoot();
        
    }
     private void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit " + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();  //call a method on EnemyHealth that decreases enemy's health
            target.Damage(damage);
        }
        else
        {
            return;
        }

    }
    private void OnEnable()
    {

        player.Enable();
        
    }
    private void OnDisable()
    {

        player.Disable();

    }
}
