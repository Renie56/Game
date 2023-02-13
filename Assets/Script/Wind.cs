using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WindTime());
    }
    IEnumerator WindTime()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
}
