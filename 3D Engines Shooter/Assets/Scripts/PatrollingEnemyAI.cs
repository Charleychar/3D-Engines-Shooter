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


    //attacking player if they step into light

    private void AttackPlayer()
    {
        aggroLight.color = Color.red;
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

    
}
