using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick : MonoBehaviour
{
    int num = 1;
    public void Start()
    {
        if (this == GameObject.FindWithTag("ObjOpt1"))
            num = 1;
        else if (this == GameObject.FindWithTag("ObjOpt2"))
            num = 2;
        else if (this == GameObject.FindWithTag("ObjOpt3"))
            num = 3;
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && mainScript.onEvent == true)
        {     
            if (num == 1)
                mainScript.do1();
            else if (num == 2)
                mainScript.do2();
            else if (num == 3)
                mainScript.do3();
        }
    }
}
