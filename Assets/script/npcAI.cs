using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcAI : MonoBehaviour
{
    public GameObject optionObj;
    public targetController tg;
    public dialog dia;

    public bool istalking;
    private void Awake()
    {
        tg = FindObjectOfType<targetController>();
        dia = FindObjectOfType<dialog>();
        istalking = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && tg.objTarget == this.gameObject && !istalking)
        {
            //optionObj.SetActive(true);
            Vector2 pos = new Vector2(transform.position.x, transform.position.y + this.GetComponent<Collider2D>().bounds.size.y / 2);
            dia.createDiabox(pos,this.gameObject, "xin chao toi la azumi"); 
            
        }
    }


}
