using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] public float speed = 20f;
    public Rigidbody2D rigidbody;
    public GameObject teapot;

    void Start()
    {
        rigidbody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);
        if(hitInfo.name == "Teapot")
        {
            Debug.Log("win");
        }
    }
}
