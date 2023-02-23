using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMove : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask WallLeft;
    [SerializeField] private LayerMask WallRight;
    bool touched = false;
    int k = 0;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        body.velocity = new Vector2(-1.4f, 0f);
        if (isTouch())
        {
            touched = false;
            boxCollider.size = new Vector2(boxCollider.size.x - 0.1f, boxCollider.size.y);
            boxCollider.offset = new Vector2(boxCollider.offset.x + 0.1f / 2, boxCollider.offset.y);
            k++;
            if (boxCollider.size.x < 0.001f)
            {
                StartCoroutine(Delay());
            }
        }
        if (isTouch2())
        {
            boxCollider.offset = new Vector2(boxCollider.offset.x - 0.1f/2, boxCollider.offset.y);
/*            Debug.Log("Yes");*/
            if(touched == false)
            {
                StartCoroutine(RegenerateCollider());
                touched = true;
            }
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        body.position = new Vector2(8f, body.position.y);
        boxCollider.size = new Vector2(0.1f, boxCollider.size.y);
        boxCollider.offset = new Vector2(boxCollider.offset.x - (0.1f * (k-4)), boxCollider.offset.y);
    }
    IEnumerator RegenerateCollider()
    {
        yield return new WaitForSeconds(0.1f);
/*        Debug.Log(0.1f * k);*/
        boxCollider.offset = new Vector2(boxCollider.offset.x + 0.1f / 2, boxCollider.offset.y);
        boxCollider.size = new Vector2(boxCollider.size.x + 0.1f, boxCollider.size.y);
        if (boxCollider.size.x <= (0.1f * (k-1)))
        {
            StartCoroutine(RegenerateCollider());
        }
        else{
            k = 0;
            boxCollider.offset = new Vector2(boxCollider.offset.x + 0.05f , boxCollider.offset.y);
            touched = false;
        }
    }
    private bool isTouch()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.left, 0.1f, WallLeft);
        return raycastHit.collider != null;
    }
    private bool isTouch2()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.left, 0.1f, WallRight);
        return raycastHit.collider != null;
    }
    private bool isTouch3()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.right, 0.1f, WallRight);
        return raycastHit.collider != null;
    }
}
