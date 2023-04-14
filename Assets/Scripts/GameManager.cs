using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public static GameManager gameManager;
    [SerializeField] Button restartButton, lastExitButton, startButton, firstExitButton;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] GameObject startPanel;
    //public bool gameOver = false;
    public static bool isStarted = false;
    public static bool isRestart;
    //private void Awake()
    //{
    //    gameManager = this;
    //}
    void Start()
    {
        if (isRestart)
        {
            startPanel.SetActive(false);
            EnemyControl enemyControl = FindObjectOfType<EnemyControl>();
            enemyControl.GetComponent<Animator>().SetBool("Reverse", true);
            enemyControl.GetComponent<Animator>().SetFloat("Rotate", 2);
        }
        restartButton.onClick.AddListener(RestartGame);
        firstExitButton.onClick.AddListener(ExitGame);
        lastExitButton.onClick.AddListener(ExitGame);
        startButton.onClick.AddListener(StartGame);
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("Coin");
    }
    void Update()
    {
        
    }
    #region Restart Game
    public void RestartGame()
    {
        isRestart = true;
        //Time.timeScale = 0;
        isStarted = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion
    #region Exit Game
    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion
    #region Start Game
    public void StartGame()
    {
        isStarted = true;
        startPanel.SetActive(false);
        EnemyControl enemyControl = FindObjectOfType<EnemyControl>();
        enemyControl.GetComponent<Animator>().SetBool("Reverse", true);
        enemyControl.GetComponent<Animator>().SetFloat("Rotate", 2);
    }
    #endregion
}
