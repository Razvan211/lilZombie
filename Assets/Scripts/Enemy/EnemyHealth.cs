using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float health = 100f;
    public GameManager gameManager;
    bool isDead = false;
    public bool IsDead()
    {
        return isDead;
    }
    
    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Damage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        health -= damage;
        if(health <= 0)
        {
            Die();
            gameManager.IncreaseScore(1);
        }    

    }
    private void Die()
    {
        if (isDead) return;

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
