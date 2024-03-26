using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
public class dialog : MonoBehaviour
{
    public GameObject prefab_boxChat;
    public TextMeshPro txtbox;
    public List<GameObject> list_dialogObj;

    public float timedelay; 

    private void Start()
    {
    }

    private void Update()
    {
    }
    public void createDiabox(Vector3 pos,GameObject person,string txtmain)
    {
        GameObject diaobj = Instantiate(prefab_boxChat, pos, Quaternion.identity);
        list_dialogObj.Add(diaobj);
        diaobj.GetComponent<boxdialog>().startText(person.transform, txtmain);

    }

}
