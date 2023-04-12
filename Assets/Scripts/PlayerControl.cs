using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] TextMeshProUGUI scoreText;
    int coinCount;
    string coinKey = "Coin";
    bool run = false;
    private void Start()
    {
        coinCount = PlayerPrefs.GetInt(coinKey);
        scoreText.text = "" + coinCount;
    }
    private void FixedUpdate()
    {
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
            PlayerPrefs.SetInt(coinKey, coinCount);
            scoreText.text = "" + coinCount;
            Destroy(collision.gameObject, 0.2f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject, 0.5f);
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
