using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Destroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyTime());
    }
    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
