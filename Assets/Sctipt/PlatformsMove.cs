using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMove : MonoBehaviour
{
    private Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        body.velocity = new Vector2(-3f, body.velocity.y);
    }
}
