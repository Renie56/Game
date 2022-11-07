using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teapot_Attack : MonoBehaviour
{
    private Animator anim;
    private bool statement;
    public Transform Firepoint;
    public GameObject BulletPref;
    public GameObject WindPref;
    private float typeOfAttack;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Delay());
    }
    void Update()
    {

    }
    IEnumerator Delay()
    {
        typeOfAttack = Random.Range(0f, 10f);
        statement = true;
        Debug.Log(typeOfAttack);
        if (typeOfAttack <= 6)
        {
            anim.SetBool("Attack", statement == true);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(DelayForBullet());
            yield return new WaitForSeconds(0.417f);
            StartCoroutine(DelayForBullet());
            yield return new WaitForSeconds(0.417f);
            StartCoroutine(DelayForBullet());
            yield return new WaitForSeconds(0.417f);
            anim.SetBool("Attack", statement != true);
            yield return new WaitForSeconds(5);
            StartCoroutine(Delay());
        }
        else if(typeOfAttack <= 9)
        {
            anim.SetBool("Attack", statement == true);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(DelayForBullet());
            yield return new WaitForSeconds(0.417f);
            StartCoroutine(DelayForBullet());
            yield return new WaitForSeconds(0.417f);
            StartCoroutine(DelayForBullet());
            yield return new WaitForSeconds(0.417f);
            anim.SetBool("Attack", statement != true);
            yield return new WaitForSeconds(5);
            StartCoroutine(Delay());
        }
        else
        {
            anim.SetBool("SuperAttack", statement == true);
            yield return new WaitForSeconds(0.35f);
            yield return Instantiate(WindPref, new Vector3(0f, 0f, 0f), WindPref.transform.rotation);
            yield return new WaitForSeconds(8);
            anim.SetBool("SuperAttack", statement != true);
            yield return new WaitForSeconds(5);
            StartCoroutine(Delay());
        }
    }

    IEnumerator DelayForBullet()
    {
        yield return Instantiate(BulletPref, Firepoint.position, Firepoint.rotation);
    }
}
