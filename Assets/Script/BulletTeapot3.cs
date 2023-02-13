using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTeapot3 : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    public Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody.velocity = new Vector3(-speed, 0f, 0f);
        transform.Rotate(0f, 0f, 90f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Wall left")
        {
            Destroy(gameObject);
        }
        else if(hitInfo.name == "Main character")
        {
            Player player = hitInfo.GetComponent<Player>();
            if (player != null)
            {
                Destroy(gameObject);
                player.TakeDamage();
            }
        }
    }
}
