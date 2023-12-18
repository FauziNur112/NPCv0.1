using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;
using System.Xml.Serialization;

public class DialogManager : MonoBehaviour
{
    public TMP_Text actorName;
    public TMP_Text message;
    public GameObject dialogBox;
    public GameObject Statusbar;
    public GameObject objektif;
/*    public PlayableDirector Timeline;*/

    Message[] currentMessages;
    Actor[] currentActor;
    int activeMessage = 0;
    public static bool isActive = false;

    public void FixedUpdate()
    {
        objektif.SetActive(!isActive);
        Statusbar.SetActive(!isActive);
    }

    public void OpenDialog(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActor = actors;
        activeMessage = 0;
        isActive = true;
        DisplayMessagge();    
    }

    void DisplayMessagge ()
    {
        dialogBox.SetActive(true);

        Message messageToDisplay = currentMessages[activeMessage];
        message.text = messageToDisplay.message;
        
        if (messageToDisplay.isPlayer)
        {
            actorName.text = PlayerPrefs.GetString("namaplayer");
        }
        else
        {
            Actor actorToDisplay = currentActor[messageToDisplay.actorId];
            actorName.text = actorToDisplay.actorName;
        }
        
    } 

    public void NextMessage ()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessagge ();
        } else
        {
            Debug.Log("Tidak ada message");
            isActive = false;
            dialogBox.SetActive(false);
            /*            Timeline.time = 1f;
                        Timeline.playableGraph.GetRootPlayable(0).SetSpeed(1f);*/
            /*Timeline.playableGraph.GetRootPlayable(0).Play();*/
            /*FindObjectOfType<TriggerDialog>().resumeKlip();*/
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            NextMessage();
        }
    }
}
