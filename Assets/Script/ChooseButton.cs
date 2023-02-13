using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseButton : MonoBehaviour
{
    public void ChooseCharacter()
    {
        SceneManager.LoadScene("Level1");
    }
}
