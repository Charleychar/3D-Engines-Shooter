using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    //parameters
    [SerializeField] float aggroRange = 10f;
    float distanceToPlayer = Mathf.Infinity;

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

    //engaging player
    public void EngagePlayer()
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

    //animations
    public void AttackPlayer()
    {
        print("attacking");
        anim.SetBool("attackingPlayer", true);
        GetComponent<EnemyAttack>().Attack();
    }

    public void ChasePlayer()
    {
        anim.SetBool("playerSpotted", true);
        anim.SetBool("attackingPlayer", false);
        nMA.SetDestination(playerTarget.position);
    }

    public void FacePlayer()
    {
        Vector3 direction = playerTarget.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
