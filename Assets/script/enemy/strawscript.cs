using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strawscript : MonoBehaviour
{
    public Animator ani;
    public Transform posCheckFront;
    public Vector2 checksize;
    public LayerMask maskCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D hit = Physics2D.OverlapBox(posCheckFront.position, checksize, 0, maskCheck);
        if (collision.CompareTag("wpSlash"))
        {
            if (hit != null) ani.SetBool("isfront", true);
            else ani.SetBool("isfront", false);
            ani.SetBool("gethit", true);
            SpriteRenderer sprite =  this.gameObject.GetComponent<SpriteRenderer>();
            sprite.color = new Color(140f / 255f, 140f / 255f, 140f / 255f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("wpSlash"))
        {
            SpriteRenderer sprite =  this.gameObject.GetComponent<SpriteRenderer>();
            sprite.color = Color.white;
        }
    }

    public void endanim()
    {
        ani.SetBool("gethit", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(posCheckFront.position, checksize);
    }
}
