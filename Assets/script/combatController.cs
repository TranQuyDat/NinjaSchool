using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatController : MonoBehaviour
{
    public combatData cbdata;
    public Animator ani;
    public int comboindex=1;
    public bool isAtk;
    private void Start()
    {
        ani.runtimeAnimatorController = cbdata.aniController;
        isAtk = false;        
        comboindex = 1;
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
