using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
public class boxdialog : MonoBehaviour
{
    public List<char> listChar;
    public int countWord;
    public dialog dia;
    public TextMeshPro txtbox;

    public float timedelay;
    public float oldtimedelay;
    public GameObject personIsTalking;
    public bool isactive;
    private void Awake()
    {
        dia = FindObjectOfType<dialog>();
        countWord = 0;
        timedelay = dia.timedelay;
        oldtimedelay = timedelay;
        isactive = true;
    }

    void Update()
    {
        if (countWord >= 68 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            txtbox.text = "";
            countWord = 0;
        }
        skipTimedelaytxt();
    }
    public void startText(Transform person, string txtmain)
    { 
        listChar = txtmain.ToCharArray().ToList(); Debug.Log(listChar);
        txtbox = this.GetComponentInChildren<TextMeshPro>();
        txtbox.text = "";
        this.personIsTalking = person.gameObject;
        personIsTalking.GetComponent<npcAI>().istalking = true;
        InvokeRepeating("nextChar", 0f, timedelay);
    }
    public void nextChar()
    {
        if (listChar == null || listChar.Count <= 0)
        {
            StartCoroutine(waitToEndText());
            return;
        }
        if (countWord >= 68) return;
        countWord += 1;
        txtbox.text += listChar[0];
        listChar.RemoveAt(0);

    }
    public void endText()
    {
        personIsTalking.GetComponent<npcAI>().istalking = false;
        CancelInvoke("nextChar");
        isactive = false;
        dia.list_dialogObj.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
    IEnumerator waitToEndText()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            endText();
            StopCoroutine(waitToEndText());
        }
        yield return new WaitForSeconds(1.5f);
        endText();
    }

    public void skipTimedelaytxt()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            timedelay = 0.1f;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            timedelay = dia.timedelay;
        }

        if (oldtimedelay != timedelay)
        {
            CancelInvoke("nextChar");
            oldtimedelay = timedelay;
            InvokeRepeating("nextChar", 0.1f, timedelay);
        }
    }
}
