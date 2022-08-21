using UnityEngine;
using UnityEngine.SceneManagement;

public class Choose_chat : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
