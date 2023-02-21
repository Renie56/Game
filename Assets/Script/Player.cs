using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 3;
    private int superAmount = 0;
    public Image[] hearts;
    public Image[] supers;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite fullSuper;
    public Sprite emptySuper;
    public PlayersMovement PlayersMovement;
    public Dragon_shoot Dragon_shoot;
    public bool animationend;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        foreach (Image heart in hearts)
        {
            heart.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
        if (health <= 0)
        {
            PlayersMovement.Death();
            Dragon_shoot.Death();
            SceneManager.LoadScene("DeadScene");

        }
        if(animationend == true)
        {
            Destroy(gameObject);
        }

        foreach (Image super in supers)
        {
            super.sprite = emptySuper;
        }
        for (int i = 0; i < superAmount; i++)
        {
            supers[i].sprite = fullSuper;
        }
        if(superAmount == 3 && Input.GetButtonDown("Fire2"))
        {
            Dragon_shoot.SuperShoot();
            superAmount = 0;
        }
    }

    public void TakeDamage()
    {
        health--;
        if (health > 0)
        {
            anim.SetBool("damage", true);
            StartCoroutine(CooldownReset());
        }
    }

    public void TakeHealth()
    {
        if (health > 0 && health < 3)
        {
            health++;
            anim.SetBool("healthing", true);
            StartCoroutine(CooldownReset());
        }
    }

    IEnumerator CooldownReset()
    {
        yield return new WaitForSeconds(0.34f);
        anim.SetBool("damage", false);
    }

    public void PickUpSuper()
    {
        if(superAmount < 3)
        {
            superAmount++;
        }
    }
}
