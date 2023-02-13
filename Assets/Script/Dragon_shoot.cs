using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon_shoot : MonoBehaviour
{

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
        yield return new WaitForSeconds(1);
        Cooldown = true;
    }

    public void SuperShoot()
    {
        /*        RaycastHit2D hitInfo =  Physics2D.Raycast(Firepoint.position, Firepoint.right);
                if (hitInfo)
                {
                    Teapot_Attack enemy = hitInfo.transform.GetComponent<Teapot_Attack>();
                    if(enemy != null)
                    {
                        enemy.Damage(16);
                        Instantiate(SuperPrefLine, new Vector3(0f, 0f, 0f), SuperPref.transform.rotation);
                    }
                }*/

/*        Instantiate(SuperPref, new Vector3(0f, 0f, 0f), SuperPref.transform.rotation);*/
        Instantiate(BulletPref, Firepoint.position, Firepoint.rotation);
    }

    public void Death()
    {
        death = true;
    }
}
