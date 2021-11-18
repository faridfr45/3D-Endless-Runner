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

    
    [Header("Score")]
    [SerializeField]private Text scoreText;
    public float scoreRate;
    public static float scoreValue;
    
    private void Start() {
        coinValue = 0;
        scoreValue = 0;

        gameOver = false;
        isGameStarted = false;
        Time.timeScale = 1;
    }

    private void Update() {
        coinText.text = coinValue.ToString();
        scoreText.text = Mathf.Round(scoreValue).ToString();

        if(isGameStarted)
            scoreValue += scoreRate * Time.deltaTime;

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
