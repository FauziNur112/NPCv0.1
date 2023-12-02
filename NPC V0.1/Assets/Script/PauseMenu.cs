using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPause = false;
    public static bool maps = false;
    public int opendiary = 0;
    public GameObject pauseMenuUI;
    public GameObject diary;
    private GameObject housemap;
    public GameObject seting;
    public static bool setting = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (maps)
            {
                tutupmap();
            }
            else
            {
                bukamap();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPause = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    void bukamap()
    {
        diary.SetActive(true);
        housemap = diary.transform.Find("maps").gameObject;
        housemap.SetActive(true);
        Time.timeScale = 0f;
        maps = true;
    }

    void tutupmap()
    {
        diary.SetActive(false);
        Time.timeScale = 1.0f;
        maps = false;
    }


}
