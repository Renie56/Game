using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_shoot : MonoBehaviour
{

    public Transform Firepoint;
    public GameObject BulletPref;
    private bool Cooldown = true;


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Cooldown == true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Cooldown = false;
        Instantiate(BulletPref, Firepoint.position, Firepoint.rotation);
        StartCoroutine(CooldownReset());
    }

    IEnumerator CooldownReset()
    {
        yield return new WaitForSeconds(1);
        Cooldown = true;
    }
}
