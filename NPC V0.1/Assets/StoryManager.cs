using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StoryManager : MonoBehaviour
{
    public PlayableDirector timelinePertama;
    public PlayableDirector timelineKedua;
    public Objectives objectives;
    public GameObject listTujuan;
    public GameObject UIPanel;
    int urutanStory = 0;
    // Start is called before the first frame update
    void Start()
    {
        timelinePertama.stopped += Director_Stopped;
        timelinePertama.played += Director_Played;
        timelineKedua.stopped += Director_Stopped;
        timelineKedua.played += Director_Played;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Director_Stopped(PlayableDirector obj) 
    {
        UIPanel.SetActive(true);
        StartStory(urutanStory);
        urutanStory++;
    }

    void Director_Played(PlayableDirector obj)
    {
        UIPanel.SetActive(false);
    }

    public void StoryOne() 
    {   

    }
    public void StoryTwo() 
    { 
    
    }  

    public void StartStory(int idStory)
    {
        switch (idStory)
        {
            case 0:
                objectives.actOne();
                listTujuan.SetActive(true);
            break;
            
            case 1:
            objectives.actTwo();
                listTujuan.SetActive(true);
                break;
        }
    }
}
