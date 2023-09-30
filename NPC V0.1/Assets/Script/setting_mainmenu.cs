using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setting_mainmenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        /*Load Playing Scene ketika klik Start New Game*/
        SceneManager.LoadScene("SampleScene");
        Debug.Log("berhasil load");
    }
}
