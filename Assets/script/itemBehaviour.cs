using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBehaviour : MonoBehaviour
{
    public GameObject player;
    public void use(itemData itemdata)
    {
        if(itemdata.tyleItem == tyleItems.wp)
        {
            itemdataWP itdata = (itemdataWP)itemdata;
            useitem(itdata);
            return;
        }
    }

    public void useitem(itemData itemdata)
    {
        //dung item hp mp ...
    }

    public void useitem(itemdataWP itemdatawp)
    {
        // dung item weapon
        combatController cbctrl = player.GetComponent<combatController>();
        cbctrl.cbdata = itemdatawp.cbdata;
        cbctrl.wpsprite.sprite = itemdatawp.handleWP;
    }
}
