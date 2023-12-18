using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.Universal;

public class StoryManager : MonoBehaviour, IDataPersistence
{
    public PlayableDirector timelinePertama;
    public PlayableDirector timelineKedua;
    public PlayableDirector timelineKetiga;
    public PlayableDirector timelineKeempat;


    public Objectives objectives;
    public GameObject listTujuan;
    public GameObject UIPanel;
    public GameObject[] tujuanPlayer;
    public GameObject markertujuan; 


    public GameObject triggerActSuara;
    public GameObject triggerActCekBoxs;
    public GameObject triggerActLevelTwo;


    public int urutanStory = -1;
    public int IDstory;


    public Light2D lampuGlobal;
    public Light2D lampuSpotPlayer;
    public Light2D lampuSenter;

    public GameObject kucing;
    // Start is called before the first frame update
    void Start()
    {
        timelinePertama.stopped += Director_Stopped;
        timelinePertama.played += Director_Played;
        timelineKedua.stopped += Director_Stopped;
        timelineKedua.played += Director_Played;
        timelineKetiga.stopped += Director_Stopped;
        timelineKetiga.played += Director_Played;
        timelineKeempat.stopped += Director_Stopped;
        timelineKeempat.played += Director_Played;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Director_Stopped(PlayableDirector obj) 
    {
/*        UIPanel.SetActive(true);*/
        SesudahStartStory(urutanStory);
        urutanStory++;
    }

    void Director_Played(PlayableDirector obj)
    {
        sebelumStartStory(urutanStory);
        
    }

    public void StoryOne() 
    {   

    }
    public void StoryTwo() 
    { 
    
    }  

    public void SesudahStartStory(int idStory)
    {
        switch (idStory)
        {
            case 0:
                objectives.actOne();
                listTujuan.SetActive(true);
                triggerActSuara.SetActive(true);
                IDstory = 0;
            break;
            
            case 1:
                objectives.actTwo();
                listTujuan.SetActive(true);
                triggerActSuara.SetActive(false);
                triggerActCekBoxs.SetActive(true);
                IDstory = 1;
                /*               triggerActThree.SetActive(true);*/
                break;
            case 2:
                objectives.actThree();
                listTujuan.SetActive(true);
                triggerActCekBoxs.SetActive(false);
                triggerActLevelTwo.SetActive(true);
                IDstory = 2;
                break;
            case 3:
                listTujuan.SetActive(false);
                lampuSpotPlayer.enabled=false;
                lampuSenter.enabled=false;
                markertujuan.SetActive(false);
                break;
        }
    }

    public void sebelumStartStory(int idStory)
    {
        switch (idStory)
        { 
            case 0:
                
                break;
            case 1:
                Destroy(kucing);
                break;
        }
    }

    public void LoadData(GameData data)
    {
        this.IDstory = data.storyID;
        if (data.storyID != 0)
        {
            SesudahStartStory(this.IDstory);
        }
            
/*        if (data.storyID == -1)
        {
            listTujuan.SetActive(false);
        }*/
    }

    public void SaveData(ref GameData data)
    {
        data.storyID = this.IDstory;
    }
}
