using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_dragon : MonoBehaviour
{
    public GameObject bossmenu;
    private Rigidbody2D body;
    private Animator anim;
    private bool statement = true;
    private bool up_down = true;
    private string statement_2 = "forward";
    private float i = 0;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0.01f && i < 4 && statement == true)
        {
            if (up_down == true)
            {
                up_down = false;
                body.velocity = new Vector3(2.5f, 0.41f, 0);
            }
            else if (up_down == false)
            {
                up_down = true;
                body.velocity = new Vector3(2.5f, -0.41f, 0);
            }
            i++;
            statement = false;
            statement_2 = "forward";
            anim.SetBool("run", statement != true);
            transform.localScale = new Vector3(1, 1, 1);
            bossmenu.active = false;
        }

        else if (horizontalInput < -0.01f && i > 1 && statement == true)
        {
            if (up_down == true)
            {
                up_down = false;
                body.velocity = new Vector3(-2.5f, 0.41f, 0);
            }
            else if (up_down == false)
            {
                up_down = true;
                body.velocity = new Vector3(-2.5f, -0.41f, 0);
            }
            i--;
            statement_2 = "backward";
            statement = false;
            anim.SetBool("run", statement != true);
            transform.localScale = new Vector3(-1, 1, 1);
            bossmenu.active = false;
        }
        float i_0 = -(20f - (4f * i));
        if ((statement_2 == "forward" && body.position.x > i_0 && statement == false) || (statement_2 == "backward" && body.position.x < i_0 && statement == false))
        {
            body.velocity = new Vector3(0, 0, 0);
            statement = true;
            anim.SetBool("run", statement != true);
            bossmenu.active = true;
        }

    }
}
