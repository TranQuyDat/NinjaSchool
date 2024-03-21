using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public enum wpTyle
{
    sw,fan,kunai,PolearmScimitar
}
[CreateAssetMenu(fileName = "itemdata_wp", menuName = "Data/items/itemWPdata")]
public class itemdataWP : itemData
{
    public wpTyle wpTyle;
    public Sprite handleWP;
    public combatData cbdata;
}
