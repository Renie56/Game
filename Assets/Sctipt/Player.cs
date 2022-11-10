using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public PlayersMovement PlayersMovement;
    public Dragon_shoot Dragon_shoot;
    public bool animationend;

    void Update()
    {
        foreach(Image heart in hearts)
        {
            heart.sprite = emptyHeart;
        }
        for(int i = 0; i<health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
        if(health <= 0)
        {
            PlayersMovement.Death();
            Dragon_shoot.Death();
        }
        if(animationend == true)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage()
    {
        health--;
    }
}
