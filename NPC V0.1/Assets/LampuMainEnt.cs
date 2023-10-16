using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LampuMainEnt : MonoBehaviour
{

    public GameObject[] lampuMainent;
    private GameObject lampu;
    private bool Onoff = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Onoff)
            {
                lampuMainent[0].SetActive(false);
                Onoff = false;
            } else
            {
                lampuMainent[0].SetActive(true);
                Onoff = true;  
         
            }
      
        }
    }
}
