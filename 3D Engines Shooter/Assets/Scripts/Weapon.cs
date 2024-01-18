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
    [SerializeField] float rateOfFire = 0.5f;
    [SerializeField] RegularEnemyHealth regHealth;
    [SerializeField] BossHealth bossHealth;

    bool canFire = true;


    [SerializeField] BossHealth bossTarget;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Regular Enemy").GetComponent<RegularEnemyHealth>();
        GameObject.Find("Boss").GetComponent<BossHealth>();
        Cursor.lockState = CursorLockMode.Locked;
        //bossTarget = GameObject.FindGameObjectWithTag("Boss").transform.GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        bossTarget = GameObject.FindGameObjectWithTag("Boss").transform.GetComponent<BossHealth>();
        print(canFire);
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            StartCoroutine(Fire());
            PlayGunFireVFX();
            
        }

        if(this.gameObject.name == "SpecialPickup")
        {
            gunFiringParticle = transform.GetChild(1).GetComponent<ParticleSystem>();
        }

    }

    //gunfire
    private void PlayGunFireVFX()
    {
        gunFiringParticle.Play();
        //print("is shooting");
    }

    public IEnumerator Fire()
    {
        canFire = false;
        Raycasting();

        yield return new WaitForSeconds(rateOfFire);
        canFire = true;
    }

    
    //raycasting
    private void CreateHitVFX(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }

    public void Raycasting()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, firingRange))
        {
            CreateHitVFX(hit);
            RegularEnemyHealth target = hit.transform.GetComponent<RegularEnemyHealth>();
            //bossTarget = hit.transform.GetComponent<BossHealth>();
            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);
            bossTarget.TakeDamage(damage);
        }
    }
}
