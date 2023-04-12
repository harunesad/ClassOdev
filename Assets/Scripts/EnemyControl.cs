using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] Animator enemyAnim;
    void Update()
    {
        if (!GameManager.gameManager.isStarted)
        {
            return;
        }
        if (transform.position.x > 6)
        {
            enemyAnim.SetBool("Reverse", true);
        }
        if (transform.position.x < 3)
        {
            enemyAnim.SetBool("Reverse", false);
        }
    }
}
