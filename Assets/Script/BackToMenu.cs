using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void BackMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
