using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTeapot : MonoBehaviour
{
    [SerializeField] public float speed = 12f;
    public Rigidbody2D rigidbody;
    public GameObject BulletPrefShadow;
    private bool afterroof = false;

    void Start()
    {
        rigidbody.velocity = new Vector3(0f, speed, 0f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Roof 2" && afterroof == false)
        {
            rigidbody.velocity = new Vector3(0f, -speed, 0f);
            transform.Rotate(0f, 180f, 0f);
            transform.position = new Vector3(transform.position.x + Random.Range(-16f, -1f), transform.position.y, transform.position.z);
            Instantiate(BulletPrefShadow, new Vector3(transform.position.x, BulletPrefShadow.transform.position.y, BulletPrefShadow.transform.position.z), Quaternion.Euler(BulletPrefShadow.transform.rotation.x, BulletPrefShadow.transform.rotation.y, BulletPrefShadow.transform.rotation.z));
            BulletPrefShadow.transform.position = new Vector3(transform.position.x, BulletPrefShadow.transform.position.y, BulletPrefShadow.transform.position.z);
            afterroof = true;
            transform.position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        }
        if (hitInfo.name == "BulletTeapotShadow(Clone)" && afterroof == true)
        {
            Destroy(gameObject);
            afterroof = false;
        }
    }
}
