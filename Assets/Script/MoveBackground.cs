using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    float speed;
    private Transform back_Transform;
    private float back_Size;
    private float back_pos;

    void Start()
    {
        back_Transform = GetComponent<Transform>();
        back_Size = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (true)
        {
            speed = 5;
        }
        MoveBack();
    }

    public void MoveBack()
    {
        back_pos += speed * Time.deltaTime;
        back_pos = Mathf.Repeat(back_pos, back_Size);
        back_Transform.position = new Vector3(back_pos, 0, 0);
    }
}
