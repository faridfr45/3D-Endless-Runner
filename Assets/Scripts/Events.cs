using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public void ReplayGame(){
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
