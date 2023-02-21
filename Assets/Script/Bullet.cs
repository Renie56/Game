using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed = 20f;
    public Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Teapot_Attack enemy = hitInfo.GetComponent<Teapot_Attack>();
        if (hitInfo.name != "Wind(Clone)" && hitInfo.name != "Super")
        {
            Destroy(gameObject);
            if (enemy != null)
            {
                enemy.Damage(2);
            }
        }
    }
}
