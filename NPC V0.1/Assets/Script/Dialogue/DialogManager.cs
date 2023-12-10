using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TMP_Text actorName;
    public TMP_Text message;
    public GameObject dialogBox;

    Message[] currentMessages;
    Actor[] currentActor;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialog(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActor = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Panjang pesan " + messages.Length);
        DisplayMessagge();
    }

    void DisplayMessagge ()
    {
        dialogBox.SetActive(true);
        Message messageToDisplay = currentMessages[activeMessage];
        message.text = messageToDisplay.message;

        Actor actorToDisplay = currentActor[messageToDisplay.actorId];
        actorName.text = actorToDisplay.actorName;
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
