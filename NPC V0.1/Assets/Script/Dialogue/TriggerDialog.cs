using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public void StartDialog () 
    {
        FindObjectOfType<DialogManager>().OpenDialog(messages, actors);
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