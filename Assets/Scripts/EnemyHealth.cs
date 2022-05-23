using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float health = 100f;
    
    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }    

    }
}
