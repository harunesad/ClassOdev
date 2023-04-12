using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] Animator enemyAnim;
    void Start()
    {
        
    }
    void Update()
    {
        if (transform.position.x > 7)
        {
            enemyAnim.SetBool("Reverse", true);
        }
        if(transform.position.x < 3)
        {
            enemyAnim.SetBool("Reverse", false);
        }
    }
}
