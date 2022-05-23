using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    Animator animator;
    AnimatorStateInfo animStateInfo;
    NavMeshAgent navMeshAgent;

   
    bool isProvoked = false;
    bool animationFinished;
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
     
           
        }
       


        if(isProvoked == true)
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
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
            {
            ChaseTarget();
            }

        if(distanceToTarget <= navMeshAgent.stoppingDistance )
            {
            AttackTarget();
            }
    } 
    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void ChaseTarget()
    {
        animator.SetBool("IsAttacking", false);
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        animator.SetBool("IsAttacking", true);
        Debug.Log(name + "attacks" + target.name);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * turnSpeed);
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
