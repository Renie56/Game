using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperDelay : MonoBehaviour
{
    public GameObject[] supersList;
    int i = 0;
    int k = 0;

    private void Update()
    {
        while (i < supersList.Length)
        {
            if (supersList[i].activeSelf == false)
            {
                k = i;
                StartCoroutine(Delay());
            }
            i += 1;
        }
        i = 0;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(Mathf.Round(Random.Range(10, 30)));
        supersList[k].SetActive(true);
    }
}
