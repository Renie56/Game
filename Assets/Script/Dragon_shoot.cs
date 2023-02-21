using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon_shoot : MonoBehaviour
{

    [SerializeField] public GameObject firepoint;
    public Transform Firepoint;
    public GameObject BulletPref;
    public GameObject SuperPref;
    public GameObject SuperPrefLine;
    private bool Cooldown = true;
    private bool death = false;


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Cooldown == true && death == false)
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
        yield return new WaitForSeconds(0.3f);
        Cooldown = true;
    }

    public void SuperShoot()
    {
        Cooldown = false;
        Instantiate(SuperPref, new Vector3(-11, 2, 0), Quaternion.Euler(0f, 0f, 0f));
        StartCoroutine(CooldownReset());
    }

    public void Death()
    {
        death = true;
    }
}
