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
    private GameObject markersloc;
    public GameObject playerbar;
    public GameObject triggertolevelthree;



    public GameObject triggerActSuara;
    public GameObject triggerActCekBoxs;
    public GameObject triggerActLevelTwo;
    public GameObject triggerhantu;


    public int urutanStory = -1;
    public int IDstory;
    public GameObject markerArrow;


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
                GameObject targetObject = GameObject.Find("Main Bedroom Bedding");
                markerArrow.GetComponent<MovePoint>().relocate(targetObject);                
                IDstory = 0;
            break;
            
            case 1:
                objectives.actTwo();
                listTujuan.SetActive(true);
                triggerActSuara.SetActive(false);
                triggerActCekBoxs.SetActive(true);
                 markersloc = GameObject.Find("Warehouse Boxes");
                markerArrow.GetComponent<MovePoint>().relocate(markersloc);
                IDstory = 1;
                /*               triggerActThree.SetActive(true);*/
                break;
            case 2:
                objectives.actThree();
                listTujuan.SetActive(true);
                triggerActCekBoxs.SetActive(false);
                triggerActLevelTwo.SetActive(true);
                 markersloc = GameObject.Find("Main Bedroom Bedding");
                markerArrow.GetComponent<MovePoint>().relocate(markersloc);
                IDstory = 2;
                break;
            case 3:
                objectives.actFour();
                triggerhantu.SetActive(true);
                triggerActSuara.SetActive(false); ;
                listTujuan.SetActive(false);
                lampuSpotPlayer.enabled=true;
                lampuSenter.enabled=false;
                lampuGlobal.intensity=0;
                markertujuan.SetActive(false);
                IDstory=3;
                playerbar.SetActive(true);
                markersloc = GameObject.Find("Electrical Wires ");
                markerArrow.GetComponent<MovePoint>().relocate(markersloc);
                break;
            case 4:
                objectives.actFive();
                listTujuan.SetActive(true);
                markertujuan.SetActive(true);
                IDstory = 4;
                markersloc = GameObject.Find("Main Bedroom Bedding");
                markerArrow.GetComponent<MovePoint>().relocate(markersloc);
                triggertolevelthree.SetActive(true);
                break;
            case 5:
                objectives.actSix();
                listTujuan.SetActive(true);
                markertujuan.SetActive(true);
                IDstory = 5;
                markersloc = markersloc = GameObject.Find("Main Bedroom Bedding");
                markerArrow.GetComponent<MovePoint>().relocate(markersloc);
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

            SesudahStartStory(this.IDstory);
        lampuGlobal.intensity = data.intentsitasLampuGlobal;

            
/*        if (data.storyID == -1)
        {
            listTujuan.SetActive(false);
        }*/
    }

    public void SaveData(ref GameData data)
    {
        data.storyID = this.IDstory;
        data.intentsitasLampuGlobal = lampuGlobal.intensity;
    }
}
