using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMove : MonoBehaviour
{
    /*    private Rigidbody2D body;
        private BoxCollider2D boxCollider;
        [SerializeField] private LayerMask WallLeft;
        int k = 0;
        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            boxCollider = GetComponent<BoxCollider2D>();
        }
        void Update()
        {
            body.velocity = new Vector2(0f, body.velocity.y);
            if (isGrounded())
            {
                boxCollider.size = new Vector2(boxCollider.size.x - 0.1f, boxCollider.size.y);
                boxCollider.offset = new Vector2(boxCollider.offset.x + 0.1f / 2, boxCollider.offset.y);
                k++;
            }
            if (boxCollider.size.x < 0.001f)
            {
                StartCoroutine(Delay());
            }
        }
        IEnumerator Delay()
        {
            body.position = new Vector2(Random.Range(-5.0f, 0.0f), body.position.y);
            boxCollider.size = new Vector2(boxCollider.size.x + (0.1f * k), boxCollider.size.y);
            boxCollider.offset = new Vector2(boxCollider.offset.x - (0.1f * k / 2), boxCollider.offset.y);
            k = 0;
            yield return new WaitForSeconds(Random.Range(0, 2));
        }
        private bool isGrounded()
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.left, 0.1f, WallLeft);
            return raycastHit.collider != null;
        }*/

    [SerializeField] public float speed = 1f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(-speed, 0f, 0f);
    }
}
