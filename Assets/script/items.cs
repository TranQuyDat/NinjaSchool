using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : itemBehaviour
{
    public string nameobj;
    public SpriteRenderer icon;
    public itemData itdata;
    public BoxCollider2D boxcollider;
    public targetController tg;

    public float radius_check = 0.3f;
    public LayerMask layermask;

    private void Awake()
    {
        tg = FindObjectOfType<targetController>();
        icon.sprite = itdata.iconIt;
        resetSize(icon.sprite);
    }
    private void Update()
    {
        collectItems();
        if (icon.sprite != itdata.iconIt)
        {
            icon.sprite = itdata.iconIt;
            resetSize(icon.sprite);
        }
    }

    public void resetSize(Sprite obj)
    {
        if (obj == null) return;
        boxcollider.offset = obj.bounds.center;
        boxcollider.size = new Vector2(obj.bounds.size.x, obj.bounds.size.y);
    }

   public void collectItems()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius_check,layermask);
        if(Input.GetKeyDown(KeyCode.E) && tg.objTarget!=null && tg.objTarget.CompareTag("items") && this.gameObject == tg.objTarget)
        {
            use(itdata,tg.player);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius_check);
    }
}
