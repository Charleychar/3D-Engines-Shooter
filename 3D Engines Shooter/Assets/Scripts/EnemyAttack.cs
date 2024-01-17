using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float attackDamage = 20f;
    [SerializeField] PlayerHealth playerTarget;

    
    public void Attack()
    {
        print("attacking");
        if (playerTarget == null)
        {
            return;
        }
        playerTarget.PlayerDamage(attackDamage);  
        
    }
}
