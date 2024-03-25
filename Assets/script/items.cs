using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : itemBehaviour
{
    public string nameobj;
    public SpriteRenderer icon;
    public itemData itdata;
    public BoxCollider2D boxcollider;
    private void Awake()
    {
        icon.sprite = itdata.iconIt;
        resetSize(icon.sprite);
    }
    private void Update()
    {
        if(icon.sprite != itdata.iconIt)
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.CompareTag("Player")  )
        {
                player = collision.gameObject;
                use(itdata);
        }
    }
}
