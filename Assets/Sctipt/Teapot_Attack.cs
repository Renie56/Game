using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teapot_Attack : MonoBehaviour
{
    private Animator anim;
    private bool statement;
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
        yield return new WaitForSeconds(1);
        anim.SetBool("Attack", statement != true);
        yield return new WaitForSeconds(2);
        StartCoroutine(Delay());
    }
}
