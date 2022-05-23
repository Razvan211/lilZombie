using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    public GameManager gameManager;

    void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Ammo>().IncreaseCurrentAmmo(ammoAmount);
            Destroy(gameObject);
            gameManager.IncreaseScore(5);
        }
    }
}
