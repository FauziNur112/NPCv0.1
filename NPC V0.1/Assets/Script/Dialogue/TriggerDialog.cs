using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerDialog : MonoBehaviour
{
    public PlayableDirector Timeline;
    public Message[] messages;
    public Actor[] actors;

    public void StartDialog () 
    {
        FindObjectOfType<DialogManager>().OpenDialog(messages, actors);
/*        Timeline = GetComponent<PlayableDirector>();
        Timeline.playableGraph.GetRootPlayable(0).SetSpeed(0f);*/
         Timeline.playableGraph.GetRootPlayable(0).Pause();
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

}