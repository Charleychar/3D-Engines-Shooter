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
    [SerializeField] AmmoPickup ammo;
    [SerializeField] BossHealth bossTarget;
    [SerializeField] AmmoType ammoType;

    bool canFire = true;

    public void OnEnable()
    {
        canFire = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Regular Enemy").GetComponent<RegularEnemyHealth>();
        GameObject.Find("Boss").GetComponent<BossHealth>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Boss") != null)
        {
            bossTarget = GameObject.FindGameObjectWithTag("Boss").transform.GetComponent<BossHealth>();
        }
        //bossTarget = GameObject.FindGameObjectWithTag("Boss").transform.GetComponent<BossHealth>();

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            StartCoroutine(Fire());   
            
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
    }

    public IEnumerator Fire()
    {
        canFire = false;

        if (ammo.GetAmmoAmmount(ammoType) > 0)
        {
            Raycasting();
            PlayGunFireVFX();
            ammo.ReduceAmmo(ammoType);
        }
        

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
            print("Raycasting");
            CreateHitVFX(hit);
            //RegularEnemyHealth target = hit.transform.GetComponent<RegularEnemyHealth>();
            GameObject target = hit.transform.gameObject;
            //bossTarget = hit.transform.GetComponent<BossHealth>();
            //if (target == null)
            //{
            //    return;
            //}
            //target.GetComponent<RegularEnemyHealth>().TakeDamage(damage);
            //bossTarget.TakeDamage(damage);
            //target.GetComponent<BossHealth>().TakeDamage(damage);
            if(target.GetComponent<RegularEnemyHealth>() != null)
            {
                target.GetComponent<RegularEnemyHealth>().TakeDamage(damage);
            }
            else if(target.GetComponent<BossHealth>() != null)
            {
                target.GetComponent<BossHealth>().TakeDamage(damage);
            }
            else
            {
                return;
            }
        }
    }
}
