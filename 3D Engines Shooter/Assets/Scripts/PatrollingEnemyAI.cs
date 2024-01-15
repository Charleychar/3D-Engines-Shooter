using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class PatrollingEnemyAI : MonoBehaviour
{
    //parameters
    [SerializeField] float aggroRange = 7f;
    float distanceToPlayer = Mathf.Infinity;
    [SerializeField] float turnSpeed = 7f;

    //references
    [SerializeField] Transform playerTarget;
    Animator anim;
    NavMeshAgent nMA;
    Vector3 startPos;
    PlayableDirector dir;

    //states
    bool Aggro = false;



    // Start is called before the first frame update
    void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        dir = GetComponent<PlayableDirector>();
        startPos = transform.position;
    }

    // Update is called once per frame
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
            ReturnToPatrol();
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
        dir.enabled = false;
        print("working");

        if (distanceToPlayer > nMA.stoppingDistance)
        {
            //ChasePlayer();
        }

        else if (distanceToPlayer <= nMA.stoppingDistance)
        {
            //AttackPlayer();
        }
        
    }

    void ReturnToPatrol()
    {
        if (distanceToPlayer > aggroRange)
        {
            dir.enabled = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

    void FacePlayer()
    {
        Vector3 direction = playerTarget.position;
    }
}
