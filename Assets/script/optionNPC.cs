using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionNPC : MonoBehaviour
{
    public dialog dia;
    public GameObject parentObj;
    public GameObject optionObj;
    public targetController tg;

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
            optionObj.SetActive(true);
        }

        if (tg.objTarget != this.gameObject)
        {
            optionObj.SetActive(false);
        }
    }

    //cac ham option 
    public void optTalking()
    {
        Debug.Log("istalking");
        Vector2 pos = new Vector2(parentObj.transform.position.x, parentObj.transform.position.y + parentObj.GetComponent<Collider2D>().bounds.size.y / 2);
        dia.createDiabox(pos, parentObj, "xin chao toi la azumi");
        optionObj.SetActive(false);
    }
}
