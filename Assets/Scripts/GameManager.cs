using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float coinValue;
    public Text coinText;

    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    private void Start() {
        coinValue = 0;

        gameOver = false;
        isGameStarted = false;
        Time.timeScale = 1;
    }

    private void Update() {
        coinText.text = coinValue.ToString();

        if(gameOver){
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        if(SwipeManager.tap){
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
