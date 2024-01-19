using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHandler : MonoBehaviour
{
    [SerializeField] Canvas winScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        winScreen.enabled = false;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Boss") == null)
        {
            print("win");
            winScreen.enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            FindObjectOfType<Weapon>().enabled = false;
            Time.timeScale = 0;
        }
    }


}
