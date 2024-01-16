using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollingEnemyAI : MonoBehaviour
{
    //parameters
    [SerializeField] float aggroRange = 5f;
    float distanceToPlayer = Mathf.Infinity;
    [SerializeField] float turnSpeed = 7f;

    //references
    [SerializeField] Transform playerTarget;
    Animator anim;
    NavMeshAgent nMA;
    Vector3 startPos;
    Light aggroLight;
    

    //states
    bool Aggro = false;



    // Start is called before the first frame update
    void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        aggroLight = GetComponent<Light>();
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
            AttackPlayer();
            
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
    private void AttackPlayer()
    {

        if (distanceToPlayer <= aggroRange)
        {
            aggroLight.color = Color.red;
        }
        
    }

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

    
}
