using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float damage;
    public Rigidbody2D rb;
    public Animator animator;
    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), 0);
    }
    private void FixedUpdate()
    {
        move();
        flip();
    }
    public void move()
    {
        if (rb.velocity.x == 0)
        {
            animator.SetBool("walk", false);
            animator.SetBool("atk", false);
            return;
        }
        animator.SetBool("walk", true);
        animator.SetBool("atk", false);
        
        Vector3 pos = new Vector3(Input.GetAxis("Horizontal"),0,0);
        rb.MovePosition(this.transform.position + pos * moveSpeed * Time.deltaTime);
    }
    public void flip()
    {
        float cur_scale = this.transform.localScale.x;
        if (rb.velocity.x == 0 || (rb.velocity.x < 0 && cur_scale < 0) || (rb.velocity.x > 0 && cur_scale > 0)) return;
        
        this.transform.localScale = new Vector3(
            (rb.velocity.x < 0) ? -1 * Mathf.Abs(cur_scale) : Mathf.Abs(cur_scale),
            1, 0
        );
    }
}
