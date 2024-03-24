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
    
    public Transform checkground;
    public Vector2 box;
    public LayerMask layerMaskground;
    public combatController combat;
    public float radiusCircle;
    public LayerMask layercheck;
    public GameObject target;
    public Collider2D[] listTarget;
    bool isgrounded;
    bool isjumping;
    int lvJump = 1;
    int num_jump = 0;
    float axisraw_x;
    int targetindex = 0;
    private void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -4f, 7));
        axisraw_x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed",Mathf.Abs(axisraw_x) );
        
        jump();
        checkGrounded();
        animator.SetFloat("y_velocity",Mathf.Round (Mathf.Clamp( rb.velocity.y,0,3) ));
   
        atk();
        target_check();
    }
    private void FixedUpdate()
    {
        move();
        flip();
    }

    public void target_check()
    {
        listTarget = Physics2D.OverlapCircleAll(transform.position, radiusCircle,layercheck);

        if (listTarget!=null && listTarget.Length > 0 && !target.active)
        {
            target.SetActive(true);
            target.transform.position = new Vector2(listTarget[targetindex].transform.position.x,
            listTarget[targetindex].transform.position.y + Mathf.Abs(listTarget[targetindex].bounds.size.y / 2));
        }
        else if(listTarget == null || listTarget.Length <= 0 && target.active)
        {
            targetindex = 0;
            listTarget = null;
            target.SetActive(false);
            
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            btn_changeTarget();
        }
    }

    public void btn_changeTarget()
    {
        if (listTarget == null || listTarget.Length <= 0) return;
        if (targetindex < listTarget.Length - 1)
            targetindex++;
        else if(targetindex > 0) targetindex--;
        target.transform.position = new Vector2(listTarget[targetindex].transform.position.x,
            listTarget[targetindex].transform.position.y + Mathf.Abs(listTarget[targetindex].bounds.size.y / 2));
    }

    public void move()
    {
        if (combat.isAtk) return;
        Vector3 pos = new Vector3(Input.GetAxisRaw("Horizontal"),0, 0);
        
        this.transform.position += pos * moveSpeed * Time.deltaTime;    
    }
    public void flip()
    {
        float cur_scale = this.transform.localScale.x;
        if (axisraw_x == 0 || (axisraw_x < 0 && cur_scale < 0) || (axisraw_x > 0 && cur_scale > 0)) return;
        
        this.transform.localScale = new Vector3(
            (axisraw_x < 0) ? -1 * Mathf.Abs(cur_scale) : Mathf.Abs(cur_scale),
            1, 0
        );
    }

    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isjumping && num_jump < lvJump)
        {
            num_jump = num_jump + 1;
            rb.velocity = new Vector2(rb.velocity.x, powerjump);
        }

        if (Input.GetKey(KeyCode.Space) && (isgrounded))
        {

            rb.velocity = new Vector2(rb.velocity.x, powerjump);
        }

    }
    public void checkGrounded()
    {
        Collider2D boxhit = Physics2D.OverlapBox(checkground.position, box,0, layerMaskground);
        if (boxhit != null && boxhit.CompareTag("ground"))
        {
            // su kien khi cham dat
            isgrounded = true;
            isjumping = false;
            num_jump = 0;
            animator.SetBool("jump", false);
            return;
        }
        else if(boxhit == null  && isgrounded)
        {
            // su kien khi chua cham dat
            isgrounded = false;
            isjumping = true;
            animator.SetBool("jump", true);
        }
    }

    public void atk()
    {
        
        if( (Input.GetKeyDown(KeyCode.E) ) 
            && !combat.isAtk)
        {
            combat.startCombo();
            
            if (combat.isAtk && isjumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y,0,7));
            }
        }
    }

   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(checkground.position, box);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radiusCircle);
    }
}
