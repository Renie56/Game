using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTeapotShadow : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "BulletTeapot(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
