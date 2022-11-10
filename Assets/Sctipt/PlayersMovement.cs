using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool die;
    [SerializeField] private float jumpForce;
    [SerializeField] public GameObject firepoint;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (die != true)
        {
            body.transform.rotation = Quaternion.Euler(0, 0, 0);
            float horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (horizontalInput > 0f)
            {
                transform.localScale = Vector3.one;
                firepoint.transform.eulerAngles = new Vector3(0, 0, 0);
            }

            else if (horizontalInput < 0f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
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
}