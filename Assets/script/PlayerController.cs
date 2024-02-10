using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float powerjump;
    public float damage;
    public Rigidbody2D rb;
    public Animator animator;
    public bool isgrounded;
    public Transform checkground;
    public float radiusground;
    public LayerMask layerMaskground;
    public bool isjumping;
    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        checkGrounded();
        jump();
        
            animator.SetFloat("y_velocity",rb.velocity.y);
   
        atk();
    }
    private void FixedUpdate()
    {
        move();
        flip();
        
        
    }
    public void move()
    {
        Vector3 pos = new Vector3(Input.GetAxisRaw("Horizontal"),0, 0);
        this.transform.position += pos * moveSpeed * Time.deltaTime;
        if (rb.velocity.x == 0 || isjumping)
        {
            animator.SetBool("walk", false);
            return;
        }
        animator.SetBool("walk", true);
        animator.SetBool("jump", false);
        
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

    public void jump()
    {
        if (isgrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            isjumping = true;
            rb.velocity =  new Vector2 (rb.velocity.x ,powerjump);
        }
        if (isgrounded && !isjumping)
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("walk", false);
            animator.SetBool("jump", true);
        }
    }
    public void checkGrounded()
    {
        Collider2D circlehit = Physics2D.OverlapCircle(checkground.position, radiusground, layerMaskground);
        if (circlehit !=null && circlehit.CompareTag("ground") && !isgrounded)
        {
            isgrounded = true;
            isjumping = false;
            return;
        }
        else if(circlehit == null  && isgrounded)
        {
            isgrounded = false;
            
        }
    }

    public void atk()
    {
        if(Input.GetKeyDown(KeyCode.E)|| Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            animator.SetBool("atk", true);
        }
    }

    public void endAtack()
    {
        animator.SetBool("atk", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkground.position, radiusground);
    }
}
