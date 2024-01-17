using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHP = 100f;
    

    public void PlayerDamage(float attackDamage)
    {

        print("taking damage");
        playerHP -= attackDamage;

        
        if (playerHP <= 0)
        {
            GetComponent<DeathHandler>().Death();
            
        }
    }
}
