using UnityEngine;
using UnityEngine.SceneManagement;

public class Choose_level : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ForLevelMenuPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
