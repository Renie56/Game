using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_dragon : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private bool statement = true;
    private bool up_down = true;
    private float i = 0;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.01f && i < 4)
        {
            if (statement == true)
            {
                if (up_down == true)
                {
                    i++;
                    up_down = false;
                    statement = false;
                    body.velocity = new Vector3(2.5f, 0.41f, 0);
                    anim.SetBool("run", body.position.x < 0);
                }
                else if (up_down == false)
                {
                    i++;
                    up_down = true;
                    statement = false;
                    body.velocity = new Vector3(2.5f, -0.41f, 0);
                    anim.SetBool("run", body.position.x < 0);
                }
            }
        }

        else if (horizontalInput < -0.01f && i > 0)
        {
            if (statement == true)
            {
                if (up_down == true)
                {
                    i--;
                    up_down = false;
                    statement = false;
                    body.velocity = new Vector3(-2.5f, 0.41f, 0);
                    anim.SetBool("run", body.position.x < 0);
                }
                else if (up_down == false)
                {
                    i++;
                    up_down = true;
                    statement = false;
                    body.velocity = new Vector3(-2.5f, -0.41f, 0);
                    anim.SetBool("run", body.position.x < 0);
                }
            }
        }
        float i_0 = -(20f - (4f * i));
        if (body.position.x > i_0)
        {
            body.velocity = new Vector3(0, 0, 0);
            statement = true;
            anim.SetBool("run", body.position.x < i_0);
        }

    }
}
