using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.Universal;

public class StoryManager : MonoBehaviour
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
    public GameObject triggerActThree;
    public GameObject triggerActFour;

    public int urutanStory = 0;


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
                markertujuan.SetActive(true);
                markertujuan.GetComponent<Marker>().OnChangeGoal(tujuanPlayer[0]);
            break;
            
            case 1:
                objectives.actTwo();
                listTujuan.SetActive(true);
                triggerActThree.SetActive(true);
                break;
            case 2:
                objectives.actThree();
                listTujuan.SetActive(true);
                lampuGlobal.enabled = true;
                lampuGlobal.intensity = 0;
                lampuSpotPlayer.enabled = true;
                lampuSenter.enabled = true;
                markertujuan.SetActive(true);
                triggerActFour.SetActive(true);
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
                markertujuan.SetActive(false);
                break;
            case 1:
                Destroy(kucing);
                break;
        }
    }
}
