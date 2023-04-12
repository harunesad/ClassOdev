using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] TextMeshProUGUI scoreText, highScoreText, lastScoreText;
    [SerializeField] GameObject gameOverPanel;
    int coinCount;
    string coinKey = "Coin";
    bool run = false;
    private void Start()
    {
        coinCount = 0;
        scoreText.text = "" + coinCount;
    }
    private void FixedUpdate()
    {
        if (GameManager.gameManager.gameOver)
        {
            return;
        }
        float h = Input.GetAxis("Horizontal");
        Mover(h);
        PlayerAnimation(h);
        PlayerRotate(h);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coinCount += 5;
            scoreText.text = "" + coinCount;
            Destroy(collision.gameObject, 0.2f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead(collision);
    }
    void Dead(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (coinCount >= PlayerPrefs.GetInt(coinKey))
            {
                PlayerPrefs.SetInt(coinKey, coinCount);
            }
            highScoreText.text = "Best Score: " + PlayerPrefs.GetInt(coinKey);
            lastScoreText.text = "Score: " + coinCount;
            gameOverPanel.SetActive(true);
            Destroy(gameObject, 0.5f);
            GameManager.gameManager.gameOver = true;
        }
    }
    #region Character Move
    void Mover(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    #endregion
    #region Character Animation
    void PlayerAnimation(float horizontal)
    {
        if (horizontal != 0)
        {
            run = true;
        }
        else
        {
            run = false;
        }
        animator.SetBool("Run", run);
    }
    #endregion
    #region Player Rotate
    void PlayerRotate(float horizontal)
    {
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (horizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    #endregion
}//Class
