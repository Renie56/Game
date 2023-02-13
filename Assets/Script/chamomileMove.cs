using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chamomileMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private BoxCollider2D boxCollider;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask WallLeft;
    [SerializeField] private LayerMask Platform;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        body.transform.rotation = Quaternion.Euler(0, 0, 0);
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.5f, 0.5f, 1);

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        /*        anim.SetBool("run", horizontalInput != 0);*/
        anim.SetBool("grounded", grounded);
/*        if (isBetweenWall() && isBetweenPlatform())
        {
            boxCollider.enabled = false;
            body.velocity = new Vector2(10f, body.velocity.y);
        }
        else
        {
            StartCoroutine(Delay1());
        }*/
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed * jumpForce);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")

            grounded = true;
    }
    private bool isBetweenWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.left, 0.1f, WallLeft);
        return raycastHit.collider != null;
    }
    private bool isBetweenPlatform()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.right, 0.1f, Platform);
        return raycastHit.collider != null;
    }
/*    IEnumerator Delay1()
    {
        yield return new WaitForSeconds(1);
        boxCollider.enabled = true;
        body.velocity = new Vector2(0f, body.velocity.y);
        break;
    }*/
}
