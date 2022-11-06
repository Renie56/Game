using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_shoot : MonoBehaviour
{

    public Transform Firepoint;
    public GameObject BulletPref;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(BulletPref, Firepoint.position, Firepoint.rotation);
    }
}
