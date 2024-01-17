using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHP = 100f;
    

    public void PlayerDamage(float attackDamage)
    {
        playerHP -= attackDamage;

        print("taking damage");
        if (playerHP <= 0)
        {
            //(gameObject);
        }
    }
}
