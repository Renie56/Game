using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Teapot_2 : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 8f;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector3(-speed, 0f, 0f);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Wall left")
        {
            Destroy(gameObject);
        }
        else if (hitInfo.name == "Main character")
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
