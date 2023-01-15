using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMachete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && mainScript.onEvent == false)
        {     
            mainScript.cocoaLoc -= 0.008f;
        }
    }
}
