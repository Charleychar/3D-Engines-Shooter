using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] float firingRange = 20f;
    [SerializeField] ParticleSystem gunFiringParticle;
    [SerializeField] GameObject hitVFX;
    [SerializeField] float damage = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RegularEnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            PlayGunFireVFX();
        }
    }

    private void PlayGunFireVFX()
    {
        gunFiringParticle.Play();
    }

    public void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, firingRange))
        {
            CreateHitVFX(hit);
            RegularEnemyHealth target = hit.transform.GetComponent<RegularEnemyHealth>();
            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);
        }

        else
        {
            return;
        } 
    }

    private void CreateHitVFX(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
