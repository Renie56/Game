using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_dragon : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private bool statement = true;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(2, body.velocity.y, 0);
        anim.SetBool("run", body.position.x < -16f);
        if (body.position.x > -16f)
        {
            body.velocity = new Vector3(0, body.velocity.y, 0);
            statement = true;
        }
        if (horizontalInput > 0.01f)
        {
            Debug.Log("a");
            if (statement == true)
            {
                statement = false;
            }
        }

    }
}
