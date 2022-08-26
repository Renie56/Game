using UnityEngine;
using UnityEngine.SceneManagement;

public class Choose_level : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayGame_2()
    {
        SceneManager.LoadScene(2);
    }
}
