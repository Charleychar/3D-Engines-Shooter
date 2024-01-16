using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEnemyHealth : MonoBehaviour
{
    [SerializeField] float hP = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        hP -= damage;
        //GetComponent<RegularEnemyAI>().EngagePlayer();


        print("doing damage");
        if(hP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
