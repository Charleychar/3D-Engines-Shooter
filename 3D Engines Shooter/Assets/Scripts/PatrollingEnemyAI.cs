using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollingEnemyAI : MonoBehaviour
{
    //parameters
    [SerializeField] float aggroRange = 7f;
    float distanceToTarget = Mathf.Infinity;
    [SerializeField] float turnSpeed = 3f;

    //references
    [SerializeField] Transform playerTarget;
    Animator anim;
    NavMeshAgent nMA;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
