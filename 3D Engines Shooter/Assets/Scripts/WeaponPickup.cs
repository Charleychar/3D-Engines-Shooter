using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    [SerializeField] GameObject Weapons;
    [SerializeField] WeaponSwitch weaponSwitch;
    [SerializeField] Transform newPos;
    [SerializeField] Ammo maxRounds;
    [SerializeField] AmmoType ammoType;

    Animator anim;
    Light pinkLight;
    Collider col;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pinkLight = GetComponent<Light>();
        col = GetComponent<BoxCollider>();
        maxRounds = GameObject.Find("Player").GetComponent<Ammo>();
    }

    public void OnTriggerEnter(Collider other)
    {
        gameObject.transform.parent = Weapons.transform;
        weaponSwitch.enabled = true;
        MaxOutRounds();
        PositionTransfer();
    }


    //to make sure the weapon gets added to player's arsenal properly
    private void PositionTransfer()
    {
        gameObject.transform.position = newPos.transform.position;
        gameObject.transform.rotation = newPos.transform.rotation;
        anim.enabled = false;
        pinkLight.enabled = false;
        col.enabled = false;
        GetComponent<WeaponPickup>().enabled = false;
    }

    public void MaxOutRounds()
    {
        if (maxRounds.GetAmmoAmmount(ammoType) < 10)
        {
            maxRounds.IncreaseAmmo(ammoType);
        }
    }
}
