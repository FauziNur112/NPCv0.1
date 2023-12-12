using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveCameraView(Camera);
        }*/

    }

    void SaveCameraView(Camera cam)
    {
        RenderTexture screenTexture = new RenderTexture(Screen.width, Screen.height, 16);
        cam.targetTexture = screenTexture;
        RenderTexture.active = screenTexture;
        cam.Render();
        Texture2D renderedTexture = new Texture2D(Screen.width, Screen.height);
        renderedTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        RenderTexture.active = null;
        byte[] byteArray = renderedTexture.EncodeToPNG();
        string fileName = "cameracapture_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";

        System.IO.File.WriteAllBytes(Application.dataPath + "/" + fileName, byteArray);
    }
}





