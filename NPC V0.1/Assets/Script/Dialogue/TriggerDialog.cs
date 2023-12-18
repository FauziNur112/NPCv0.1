using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerDialog : MonoBehaviour
{
    public PlayableDirector Timelines;
    public Message[] messages;
    

    public Actor[] actors;
    /*    public List<string> actors = new List<string>();*/

    private void Start()
    {


    }
    public void StartDialog () 
    {
        FindObjectOfType<DialogManager>().OpenDialog(messages, actors);
        /*        Timeline = GetComponent<PlayableDirector>();
                Timeline.playableGraph.GetRootPlayable(0).SetSpeed(0f);*/
/*        if (Timelines != null)
        {
            Timelines.playableGraph.GetRootPlayable(0).Pause();
        }*/
         
        
    }

    public void resumeKlip ()
    {
        if (Timelines != null)
        {
            Timelines.playableGraph.GetRootPlayable(0).Play();
        }
       
    }

}

[System.Serializable]
public class Actor
{
    public string actorName;
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
    public bool isPlayer;

}