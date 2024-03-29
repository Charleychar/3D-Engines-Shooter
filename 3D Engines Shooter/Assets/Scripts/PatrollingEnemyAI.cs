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
    Light aggroLight;

    GameObject specialWeapon;
    GameObject pistolWeapon;



    //states
    bool Aggro = false;



    // Start is called before the first frame update
    void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        aggroLight = GetComponent<Light>();
        pistolWeapon = GameObject.Find("Pistol");
        specialWeapon = GameObject.Find("SpecialPickup");

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
            anim.enabled = true;
            Aggro = false;
            anim.SetBool("PlayerInRange", false);
            aggroLight.color = Color.cyan;
            pistolWeapon.GetComponent<Weapon>().enabled = true;
            specialWeapon.GetComponent<Weapon>().enabled = true;
            CancelInvoke("KillPlayer");
        }
    }

    //attacking player if they step into light
    public void AttackPlayer()
    {
        anim.enabled = false;
        aggroLight.color = Color.red;
        anim.SetBool("PlayerInRange", true);
        pistolWeapon.GetComponent<Weapon>().enabled = false;
        specialWeapon.GetComponent<Weapon>().enabled = false;
        Invoke("KillPlayer", 4);
        
    }

    //if the player stays in the light for too long
    public void KillPlayer()
    {
        if (playerTarget == null)
        {
            return;
        }
        print("killed player");
        GameObject.Find("Player").GetComponent<DeathHandler>().Death();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

    
}
