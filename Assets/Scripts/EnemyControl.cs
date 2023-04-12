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
        if (transform.position.x > 6.5f)
        {
            enemyAnim.SetBool("Reverse", true);
        }
        if(transform.position.x < 4)
        {
            enemyAnim.SetBool("Reverse", false);
        }
    }
}
