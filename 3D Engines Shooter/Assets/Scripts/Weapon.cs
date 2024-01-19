using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    //parameters
    [SerializeField] Camera playerCam;
    [SerializeField] float firingRange = 20f;
    [SerializeField] ParticleSystem gunFiringParticle;
    [SerializeField] GameObject hitVFX;
    [SerializeField] float damage = 10f;
    [SerializeField] float rateOfFire = 0.5f;
    
    //references
    [SerializeField] RegularEnemyHealth regHealth;
    [SerializeField] BossHealth bossHealth;
    [SerializeField] Ammo ammo;
    [SerializeField] BossHealth bossTarget;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] GameObject weapons;
    

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
    public void Update()
    {
        if(GameObject.FindGameObjectWithTag("Boss") != null)
        {
            bossTarget = GameObject.FindGameObjectWithTag("Boss").transform.GetComponent<BossHealth>();
        }

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            StartCoroutine(Fire());   
            
        }

        if (this.gameObject.name == "SpecialPickup")
        {
            gunFiringParticle = transform.GetChild(1).GetComponent<ParticleSystem>();
        }
        DisplayAmmo();  
    }

    

    private void DisplayAmmo()
    {
        int currentAmmo = ammo.GetAmmoAmmount(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

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
            GameObject target = hit.transform.gameObject;
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
