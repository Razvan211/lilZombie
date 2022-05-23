using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    Animator animator;
    NavMeshAgent navMeshAgent;

    bool isWalking = false;
    bool isProvoked = false;
    float distanceToTarget = Mathf.Infinity;
   
   
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

   
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            isWalking = true;
           
        }
        else
        {
            isWalking = false;
        }


        if(isWalking == true)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }    
        
        
    }
    private void EngageTarget()
    {
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
            {
            ChaseTarget();
            }

        if(distanceToTarget <= navMeshAgent.stoppingDistance )
            {
            AttackTarget();
            }
    } 

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        Debug.Log(name + "attacks" + target.name);
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
