using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEnemyHealth : MonoBehaviour
{
    [SerializeField] float hP = 50f;
    
    public void TakeDamage(float damage)
    {
        hP -= damage;

        print("doing damage");
        if(hP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
