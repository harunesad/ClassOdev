using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] Button restartButton, exitButton, startButton;
    public bool gameOver = false;
    private void Awake()
    {
        gameManager = this;
    }
    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
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
}
