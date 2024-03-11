using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D.Animation ;
using TMPro;

public class createPlayer : MonoBehaviour
{
    public SpriteLibraryAsset[] list_headasset ;
    public SpriteLibraryAsset cur_assetBody ;
    public SpriteLibrary sl_head;
    public SpriteLibrary sl_body;
    public TextMeshProUGUI txt_name;
    public int numhead = 0;
    public playerData playerdata;
    private void Start()
    {
        sl_head.spriteLibraryAsset = list_headasset[numhead];
        sl_body.spriteLibraryAsset = cur_assetBody;
    }
    public void btn_left()
    {
       if (list_headasset.Length == 0) return;
        numhead -= 1;
        if (numhead < 0) numhead = list_headasset.Length-1;
        sl_head.spriteLibraryAsset = list_headasset[numhead];
    }
    public void btn_right()
    {
        if (list_headasset.Length == 0) return;
        numhead += 1;
        if (numhead > list_headasset.Length - 1) numhead = 0;
        sl_head.spriteLibraryAsset = list_headasset[numhead];
    }

    public void btn_create()
    {
        playerdata.asset_body = sl_body.spriteLibraryAsset;
        playerdata.asset_head = sl_head.spriteLibraryAsset;
        playerdata.name = txt_name.text;
    }

    public void btn_back()
    {

    }
}
