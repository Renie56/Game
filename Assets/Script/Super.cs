using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super : MonoBehaviour
{
    private Animator anim;
    private CapsuleCollider2D capsuleCollider;
    private SpriteRenderer spriteRenderer;
    bool delayStarted = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider.enabled = !capsuleCollider.enabled;
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }

    private void Update()
    {
        if (capsuleCollider.enabled == false && delayStarted == false)
        {
            delayStarted = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(Mathf.Round(Random.Range(10, 30)));
        capsuleCollider.enabled = !capsuleCollider.enabled;
        spriteRenderer.enabled = !spriteRenderer.enabled;
        anim.SetBool("Appeare", delayStarted == true);
        yield return new WaitForSeconds(0.7f);
        anim.SetBool("Appeare", delayStarted != true);
        delayStarted = false;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.PickUpSuper();
            capsuleCollider.enabled = !capsuleCollider.enabled;
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }
    }
}
