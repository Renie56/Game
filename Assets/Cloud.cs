using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DeleteTime());
    }
    IEnumerator DeleteTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
