using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthHeart : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    public Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody.velocity = new Vector3(0f, -speed, 0f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.name == "Floor1")
        {
            Destroy(gameObject);
        }

        else if (hitInfo.name == "Main character")
        {
            Player player = hitInfo.GetComponent<Player>();
            if (player != null)
            {
                Destroy(gameObject);
                player.TakeHealth();
            }
        }
    }
}