using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName ="playerdata",menuName ="Data/plauerData")]
public class playerData : ScriptableObject
{
    public string name;
    public SpriteLibraryAsset asset_body;
    public SpriteLibraryAsset asset_head;
}
