using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTeapot : MonoBehaviour
{
    [SerializeField] public float speed = 12f;
    [SerializeField] public float speedAfterDrop = 1f;
    public Rigidbody2D rigidbody;
    private bool afterroof = false;
    private bool afterland = false;
    private float afterdrop = 0;

    void Start()
    {
        rigidbody.velocity = new Vector3(0f, speed, 0f);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Roof 2" && afterroof == false)
        {
            rigidbody.velocity = new Vector3(0f, -speed, 0f);
            transform.Rotate(0f, 180f, 0f);
            transform.position = new Vector3(GameObject.Find("Main character").transform.position.x, transform.position.y, transform.position.z);
            afterroof = true;
            transform.position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180);
        }
        if (hitInfo.name == "Floor" && afterroof == true && afterland == false)
        {
            afterdrop = Mathf.Round(Random.Range(1, 3));
            if (afterdrop == 1)
            {
                rigidbody.velocity = new Vector3(speedAfterDrop, 0f, 0f);
            }
            else
            {
                rigidbody.velocity = new Vector3(-speedAfterDrop, 0f, 0f);
            }
            afterland = true;
        }
        else if((hitInfo.name == "Platforms" || hitInfo.name == "Platforms (1)") && afterroof == true && afterland == false)
        {
            rigidbody.gravityScale = 1f;
            afterdrop = Mathf.Round(Random.Range(1, 3));
            if (afterdrop == 1)
            {
                rigidbody.velocity = new Vector3(speedAfterDrop, 0f, 0f);
            }
            else
            {
                rigidbody.velocity = new Vector3(-speedAfterDrop, 0f, 0f);
            }
            afterland = true;
        }
        else if (hitInfo.name == "Floor" && afterland == true)
        {
            rigidbody.gravityScale = 0;
            if (afterdrop == 1)
            {
                rigidbody.velocity = new Vector3(speedAfterDrop, 0f, 0f);
            }
            else
            {
                rigidbody.velocity = new Vector3(-speedAfterDrop, 0f, 0f);
            }
        }
        if ((hitInfo.name == "Wall left" || hitInfo.name == "Wall right") && afterroof == true)
        {
            Destroy(gameObject);
        }
        else if(hitInfo.name == "Main character" && afterroof == true)
        {
            Player player = hitInfo.GetComponent<Player>();
            if (player != null)
            {
                Destroy(gameObject);
                player.TakeDamage();
            }
        }
    }
}