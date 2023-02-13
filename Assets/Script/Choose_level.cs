using UnityEngine;
using UnityEngine.SceneManagement;

public class Choose_level : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ForLevelMenuPlay()
    {
        if (player1.active == true) { SceneManager.LoadScene("SampleScene"); }
        else if (player2.active == true) { SceneManager.LoadScene("Level1_chamomile"); }
    }
}
