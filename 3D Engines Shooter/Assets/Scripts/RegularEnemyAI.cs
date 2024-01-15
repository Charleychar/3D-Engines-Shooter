using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RegularEnemyAI : MonoBehaviour
{
    //parameters
    [SerializeField] float aggroRange = 10f;
    float distanceToPlayer = Mathf.Infinity;
    [SerializeField] float turnSpeed = 7f;

    //references
    [SerializeField] Transform playerTarget;
    NavMeshAgent nMA;
    Animator anim;
    Vector3 startPos;

    //states
    bool Aggro = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        startPos = transform.position; 
    }


    //checking if player is in range
    void Update()
    {
        Raycasting();

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

        if (distanceToPlayer > aggroRange)
        {
            Aggro = false;
        }
    }


    private void Raycasting()
    {
        RaycastHit enemyLineOfSight;
        Debug.DrawRay(transform.position, gameObject.transform.forward, Color.green);
        
    }
    
    //engaging player
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
        anim.SetBool("playerSpotted",true);
        anim.SetBool("attackingPlayer", false);
        nMA.SetDestination(playerTarget.position);

        if (distanceToPlayer > aggroRange)
        {
            anim.SetBool("playerSpotted", false);
            nMA.SetDestination(startPos);
        }

    }

    private void FacePlayer()
    {
        Vector3 direction = playerTarget.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
