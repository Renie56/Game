using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMoves_Level1 : MonoBehaviour
{
    /*[SerializeField] private float speed_right_left = 5;
    [SerializeField] private float speed_top_bottom = 1;*/
    [SerializeField]  private float speed_right_left = 3;
    [SerializeField]  private float speed_top_bottom = 2;
    private Rigidbody2D body;
    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        body.transform.rotation = Quaternion.Euler(0, 0, 0);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");
        body.velocity = new Vector2(horizontalInput * speed_right_left, verticallInput * speed_top_bottom);

        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (horizontalInput != 0 && verticallInput != 0)
        {
            speed_right_left = 2;
            speed_top_bottom = 1.5f;
        }
        else
        {
            speed_right_left = 3;
            speed_top_bottom = 2;
        }

        anim.SetBool("run", horizontalInput != 0 && verticallInput == 0);
        anim.SetBool("up", verticallInput != 0);
    }
}
