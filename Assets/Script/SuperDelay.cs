using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperDelay : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxCollider;
    public GameObject super;
    bool delayStarted = false;

    private void Update()
    {
        if (super.activeSelf == false && delayStarted == false)
        {
            delayStarted = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(Mathf.Round(Random.Range(10, 30)));
        super.SetActive(true);
        anim.SetBool("Appeare", delayStarted == true);
        yield return new WaitForSeconds(0.7f);
        anim.SetBool("Appeare", delayStarted != true);
        delayStarted = false;
    }
}
