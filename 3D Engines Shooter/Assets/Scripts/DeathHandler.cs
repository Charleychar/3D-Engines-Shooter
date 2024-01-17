using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOver;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = false;
    }

    public void Death()
    {
        print("dead");
        gameOver.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<Weapon>().enabled = false;
        Time.timeScale = 0;
    }

   
}
