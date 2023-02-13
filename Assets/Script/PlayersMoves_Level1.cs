using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMoves_Level1 : MonoBehaviour
{
    [SerializeField] private float speed_right_left = 3;
    [SerializeField] private float speed_top_bottom = 2;
    [SerializeField] private LayerMask enemyLayer_1;
    [SerializeField] private LayerMask enemyLayer_2;
    public GameObject fight_start_menu;
    public GameObject fight_start_menu_2;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        fight_start_menu.SetActive(false);
        fight_start_menu_2.SetActive(false);
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

        if (TouchEnemy_1())
        {
            fight_start_menu.SetActive(true);
        }
        else if (TouchEnemy_2())
        {
            fight_start_menu_2.SetActive(true);
        }

        anim.SetBool("up", verticallInput != 0 && horizontalInput == 0);
        anim.SetBool("run", horizontalInput != 0 && verticallInput != 0);/*Should be Up-Run*/
        anim.SetBool("run", verticallInput != 0 && horizontalInput != 0);/*Should be Bottom-Run*/
        anim.SetBool("run", horizontalInput != 0 && verticallInput == 0);
    }
    private bool TouchEnemy_1()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, transform.localScale.y), 0.1f, enemyLayer_1); // center point of BoxCast , size, angle, direction, distance, check the layer of the ground, not enemies or oyher things 
        return raycastHit.collider != null;
    }
    private bool TouchEnemy_2()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, transform.localScale.y), 0.1f, enemyLayer_2); // center point of BoxCast , size, angle, direction, distance, check the layer of the ground, not enemies or oyher things 
        return raycastHit.collider != null;
    }
}


/*    private void Update()
    {
        if(does == true)
        {
            anim.SetBool("run", Input.GetKey("d") && updown == true);
            if (Input.GetKey("d") && updown == true)
            {
                updown = false;
                transform.position = new Vector2(body.position.x + 3f, body.position.y + 0.6f);
            }
            anim.SetBool("run", Input.GetKey("d") && updown == true);

            if (TouchEnemy_1())
            {
                fight_start_menu.SetActive(true);
            }
            else if (TouchEnemy_2())
            {
                fight_start_menu_2.SetActive(true);
            }

            anim.SetBool("up", verticallInput != 0 && horizontalInput == 0);
            anim.SetBool("run", horizontalInput != 0 && verticallInput != 0); Should be Up - Run
                        anim.SetBool("run", verticallInput != 0 && horizontalInput != 0); Should be Bottom - Run
                        anim.SetBool("run", horizontalInput != 0);
        } 
    }
    private bool TouchEnemy_1()
    {
        does = true;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, transform.localScale.y), 0.1f, enemyLayer_1); // center point of BoxCast , size, angle, direction, distance, check the layer of the ground, not enemies or oyher things 
        return raycastHit.collider != null;
    }
    private bool TouchEnemy_2()
    {
        does = true;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, transform.localScale.y), 0.1f, enemyLayer_2); // center point of BoxCast , size, angle, direction, distance, check the layer of the ground, not enemies or oyher things 
        return raycastHit.collider != null;
    }
}*/

