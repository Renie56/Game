using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teapot_Attack : MonoBehaviour
{
    private Animator anim;
    private bool statement;
    public Transform Firepoint;
    public GameObject BulletPref;
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
        statement = true;
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

    IEnumerator DelayForBullet()
    {
        yield return Instantiate(BulletPref, Firepoint.position, Firepoint.rotation);
    }
}
