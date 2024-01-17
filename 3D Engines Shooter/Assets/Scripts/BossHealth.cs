using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] float hP = 150f;

    public void TakeDamage(float damage)
    {
        hP -= damage;

        print("doing damage");
        if (hP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
