using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.PickUpSuper();
            gameObject.SetActive(false);
        }
    }
}
