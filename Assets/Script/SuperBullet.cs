using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBullet : MonoBehaviour
{
    [SerializeField] public float speed = 20f;
    public Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Teapot_Attack enemy = hitInfo.GetComponent<Teapot_Attack>();
        if (hitInfo.name == "Teapot")
        {
            StartCoroutine(Delay());
            if (enemy != null)
            {
                enemy.Damage(16);
            }
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
