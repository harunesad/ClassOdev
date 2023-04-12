using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] bool isGround = true;
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] float jumpSpeed = 10;
    public bool doubleJump;
    void Start()
    {
        
    }
    void Update()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, 0.25f, mask);
        if (raycastHit2D.collider != null)
        {
            isGround = true;
            doubleJump = false;
        }
        else
        {
            isGround = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
        //else if (!doubleJump && Input.GetKeyUp(KeyCode.Space))
        //{
        //    doubleJump = true;
        //}
        else if (!doubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            doubleJump = true;
        }
    }
    private void FixedUpdate()
    {


    }
}//Class
