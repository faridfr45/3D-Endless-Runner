using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public void ReplayGame(){
        SceneManager.LoadScene("Gameplay");
        if(GameObject.Find("BGM(Clone)") != null){
            Destroy(GameObject.Find("BGM(Clone)"));
        }
    }

    public void MainMenu(){
        SceneManager.LoadScene("Main Menu");
    }

    public void Shop(){
        SceneManager.LoadScene("Shop");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
