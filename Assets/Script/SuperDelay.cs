using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperDelay : MonoBehaviour
{
    public GameObject super;
    int i = 0;
    int k = 0;
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
        delayStarted = false;
        Debug.Log("a");
    }
}
