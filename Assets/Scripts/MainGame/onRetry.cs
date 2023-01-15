using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onRetry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        Debug.Log("hihihihi");
        if(Input.GetMouseButtonDown(0))
        {     
             Debug.Log("ehy");
            SceneManager.LoadScene("start");
        }
    }
}
