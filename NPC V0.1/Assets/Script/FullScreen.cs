using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void Change()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("changed screen mode");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
