using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatController : MonoBehaviour
{
    public combatData cbdata;
    public SpriteRenderer wpsprite;
    public Animator ani;
    public int comboindex=1;
    public bool isAtk;
    private void Start()
    {
        ani.runtimeAnimatorController = cbdata.aniController;
        isAtk = false;        
        comboindex = 1;
    }
    private void Update()
    {
        if (ani.runtimeAnimatorController != cbdata.aniController)
        {
            ani.runtimeAnimatorController = cbdata.aniController;
        }
    }
    public void startCombo()
    {
        isAtk = true;
        ani.SetBool("atk", true);

        ani.SetTrigger("cb" + comboindex);
    }

    public void nextCombo()
    {
        isAtk = false;
        if(comboindex < 2)
            comboindex ++;
    }

    public void finishCombo()
    {
        ani.SetBool("atk", false);
        comboindex = 1;
        isAtk = false;
    }


}
