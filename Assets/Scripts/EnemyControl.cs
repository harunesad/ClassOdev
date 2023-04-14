using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] Animator enemyAnim;
    [SerializeField] float minX, maxX;
    void Update()
    {
        if (!GameManager.isStarted)
        {
            return;
        }
        if (transform.position.x > maxX)
        {
            enemyAnim.SetBool("Reverse", false);
        }
        if (transform.position.x < minX)
        {
            enemyAnim.SetBool("Reverse", true);
        }
    }
}
