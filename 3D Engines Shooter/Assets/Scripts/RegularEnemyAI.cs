using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RegularEnemyAI : MonoBehaviour
{
    //parameters
    [SerializeField] float aggroRange = 5f;
    float distanceToTarget = Mathf.Infinity;
    [SerializeField] float turnSpeed = 3f;

    //references
    [SerializeField] Transform playerTarget;
    NavMeshAgent nMA;
    Animator anim;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
