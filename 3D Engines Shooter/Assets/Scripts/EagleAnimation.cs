using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleAnimation : MonoBehaviour
{

    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnimation()
    {
        anim.Play("Idle");
    }
}
