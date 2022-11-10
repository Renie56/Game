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
        if(health == 0)
        {
            Debug.Log("You died");
        }
    }
    public void TakeDamage()
    {
        health--;
    }
}
