using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RegularEnemyAI : MonoBehaviour
{
    //parameters
    [SerializeField] float aggroRange = 5f;
    float distanceToPlayer = Mathf.Infinity;
    [SerializeField] float turnSpeed = 3f;

    //references
    [SerializeField] Transform playerTarget;
    NavMeshAgent nMA;
    Animator anim;

    //states
    bool Aggro = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    //public static bool Raycast(Vector3 gameObject, Vector3 forwards, float aggroRange);
    
    
    
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null)
        {
            distanceToPlayer = Vector3.Distance(playerTarget.position, transform.position);
        }

        if (Aggro)
        {
            EngagePlayer();
        }

        else if (distanceToPlayer <= aggroRange)
        {
            Aggro = true;
        }
    }

    private void EngagePlayer()
    {
        FacePlayer();

        if (distanceToPlayer > nMA.stoppingDistance)
        {
            ChasePlayer();
        }

        else if (distanceToPlayer <= nMA.stoppingDistance)
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        anim.SetBool("attackingPlayer", true);
    }

    private void ChasePlayer()
    {
        anim.SetTrigger("playerSpotted");
        anim.SetBool("attackingPlayer", false);
        nMA.SetDestination(playerTarget.position);

    }

    private void FacePlayer()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
