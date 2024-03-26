using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class targetController : MonoBehaviour
{
    public GameObject player;
    public float radiusCircle;
    public LayerMask layercheck;
    public List<Collider2D> listTarget;
    public TextMeshProUGUI txt_nameTarget;
    public GameObject objTarget;
    int targetindex = 0;
    // Update is called once per frame
    void Update()
    {
        target_check();

    }

    public void target_check()
    {
        listTarget = Physics2D.OverlapCircleAll(player.transform.position, radiusCircle, layercheck).ToList();
        SpriteRenderer sprite = this.GetComponentInChildren<SpriteRenderer>();
        this.gameObject.SetActive(true);
        sprite.enabled = true;
        if (listTarget == null || listTarget.Count <= 0 || !sprite.enabled || targetindex > listTarget.Count - 1)
        {
            //thuc hien khi target khong target vao dau || targetindex da vuot ra ngoai range
            targetindex = 0;
            sprite.enabled = false;
            txt_nameTarget.text = "";
            objTarget = null;
            return;
        }

        this.transform.position = new Vector2(listTarget[targetindex].transform.position.x, //set vi tri cho target
        listTarget[targetindex].transform.position.y + Mathf.Abs(listTarget[targetindex].bounds.size.y / 2));
        nameTarget(listTarget[targetindex].gameObject); // ham gan name cho txt_nametarget;
        objTarget = listTarget[targetindex].gameObject;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            btn_changeTarget();
        }
    }

    public void nameTarget(GameObject obj)
    {
        if (obj.CompareTag("items"))
        {
            items it = obj.GetComponent<items>();
            txt_nameTarget.text = it.nameobj;
            return;
        }
        if (obj.CompareTag("npc"))
        {
            return;
        }
    }

    public void btn_changeTarget()
    {
        if (listTarget == null || listTarget.Count <= 0) return;
        targetindex++;
        if (targetindex > listTarget.Count - 1) targetindex = 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(player.transform.position, radiusCircle);
    }
}
