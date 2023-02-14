using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool grounded;
    private bool die;
    [SerializeField] private float jumpForce;
    [SerializeField] public GameObject firepoint;
    [SerializeField] private LayerMask Stick;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if ((isSticked()|| isSticked2()))
        {
            body.velocity = new Vector2(body.velocity.x, (-1.2f)*speed);
        }
        if (die != true)
        {
            body.transform.rotation = Quaternion.Euler(0, 0, 0);
            float horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (horizontalInput > 0f)
            {
                transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                firepoint.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            else if (horizontalInput < 0f)
            {
                transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
                firepoint.transform.eulerAngles = new Vector3(0, 180, 0);
            }

            if (Input.GetKey(KeyCode.Space) && grounded)
                Jump();

            anim.SetBool("run", horizontalInput != 0);
            anim.SetBool("grounded", grounded);
        }
        else
        {
            anim.SetBool("die", die);
        }
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

    public void Death()
    {
        die = true;
    }

    private bool isSticked()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.left, 0.1f, Stick);
        return raycastHit.collider != null;
    }
    private bool isSticked2()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.right, 0.1f, Stick);
        return raycastHit.collider != null;
    }
}