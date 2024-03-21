using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tyleItems
{
    wp,it_quest,it_ToUse
}
[CreateAssetMenu(fileName = "itemdata", menuName = "Data/items/itemdata")]
public class itemData : ScriptableObject
{
    public Sprite iconIt;
    public tyleItems tyleItem;
}


