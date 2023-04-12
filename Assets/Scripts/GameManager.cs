using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] Button restartButton, exitButton, startButton;
    [SerializeField] GameObject startPanel;
    //public bool gameOver = false;
    public bool isStarted = false;
    private void Awake()
    {
        gameManager = this;
    }
    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
        startButton.onClick.AddListener(StartGame);
    }
    void Update()
    {
        
    }
    #region Restart Game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
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
    }
    #endregion
}
