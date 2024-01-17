using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEnemyAttack : MonoBehaviour
{
    [SerializeField] float attackDamage = 20f;
    [SerializeField] PlayerHealth playerTarget;
    
    
    public void Attack()
    {
        playerTarget.PlayerDamage(attackDamage);
    }
}
