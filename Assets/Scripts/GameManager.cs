using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    [Header("UI Coin")]
    [SerializeField] private GameObject coinObject;
    public float coinValue;
    public Text coinText;

    [Header("UI Game Over")]
    public bool gameOver;
    [SerializeField] private GameObject gameOverPanel;

    [Header("UI Starting")]
    public bool isGameStarted;
    [SerializeField] private GameObject startingText;

    [Header("UI Pause")]
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pausePanel;

    
    [Header("Score")]
    [SerializeField]private Text scoreText;
    [SerializeField]private Text finishScore;
    [SerializeField]private Text highScoreText;
    public float scoreRate;
    public float scoreValue;
    public float highScore;

    [Header("Power Up")]
    public bool senterCanSpawn;

    private bool canSaveGold = true;

    
    private void Start() {
        coinValue = 0;
        scoreValue = 0;

        senterCanSpawn = true;
        gameOver = false;
        isGameStarted = false;
        Time.timeScale = 1;
        HideUI();
    }

    private void Update() {
        coinText.text = coinValue.ToString();
        scoreText.text = Mathf.Round(scoreValue).ToString();

        if(isGameStarted){
            scoreValue += scoreRate * Time.deltaTime;
            ShowUI();
        }

        if(gameOver){
            Time.timeScale = 0;
            finishScore.text = Mathf.Round(scoreValue).ToString();
            setHighScore();
            AddGold();
            highScoreText.text = Mathf.Round(DataManager.highScoreValue).ToString();
            gameOverPanel.SetActive(true);
            HideUI();
        }

        if(SwipeManager.tap){
            isGameStarted = true;
            Destroy(startingText);
        }
    }

    private void AddGold(){
        if(canSaveGold){
            DataManager.coinValue += coinValue;
            canSaveGold = false;
        }
    }

    private void setHighScore(){
        if(scoreValue > DataManager.highScoreValue){
            DataManager.highScoreValue = scoreValue;
        }
    }

    public void PauseGame(){
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    private void HideUI(){
        coinObject.SetActive(false);
        pauseButton.SetActive(false);
        scoreText.enabled = false;
    }

    private void ShowUI(){
        coinObject.SetActive(true);
        pauseButton.SetActive(true);
        scoreText.enabled = true;
    }
}
