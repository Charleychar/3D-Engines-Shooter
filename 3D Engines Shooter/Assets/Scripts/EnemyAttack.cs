using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float attackDamage = 20f;
    [SerializeField] PlayerHealth playerTarget;
    bool isAbleToAttack = true;
    
    public void Attack()
    {
        print("attacking");
        if (playerTarget == null)
        {
            return;
        }
        if (isAbleToAttack)
        {
            playerTarget.PlayerDamage(attackDamage);
            isAbleToAttack = false;
            Invoke("AbleToAttack", 1f);
        }
          
        
    }

    void AbleToAttack()
    {
        isAbleToAttack = true;
    }

}
