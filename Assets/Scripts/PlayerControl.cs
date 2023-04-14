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
    [SerializeField] AudioSource deathSound, coinSound;
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
        if (!GameManager.isStarted)
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
            CoinCollect(collision, 5);
        }
        if (collision.CompareTag("SuperCoin"))
        {
            CoinCollect(collision, 15);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Dead(collision.gameObject);
    }
    #region CoinCollect
    void CoinCollect(Collider2D collision, int ınc)
    {
        coinCount += ınc;
        scoreText.text = "" + coinCount;
        coinSound.Play();
        Destroy(collision.gameObject, 0.2f);
    }
    #endregion
    #region Dead
    void Dead(GameObject obj)
    {
        if (obj.CompareTag("Enemy") || obj.CompareTag("Death"))
        {
            if (coinCount >= PlayerPrefs.GetInt(coinKey))
            {
                PlayerPrefs.SetInt(coinKey, coinCount);
            }
            highScoreText.text = "Best Score: " + PlayerPrefs.GetInt(coinKey);
            lastScoreText.text = "Score: " + coinCount;
            gameOverPanel.SetActive(true);
            animator.SetBool("Run", false);
            deathSound.Play();
            Destroy(gameObject, 0.5f);
            GameManager.isStarted = false;
            EnemyControl enemyControl = FindObjectOfType<EnemyControl>();
            enemyControl.GetComponent<Animator>().SetFloat("Rotate", 1);
        }
    }
    #endregion
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
