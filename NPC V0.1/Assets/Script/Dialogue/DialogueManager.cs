using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;


    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion Singleton



    public TMP_Text text;
    public TMP_Text Name;
    public SpriteRenderer rendererDialogueWindow;


    private List<string> listSentences;
    private List<string> listName;
    private List<Sprite> listDialogueWindows;


    private int count;


   // public Animator animeDialogueWindow;


   void Start()
    {
        count = 0;
        text.text = "";
        listSentences = new List<string>();
        listName = new List<string>();
        listDialogueWindows = new List<Sprite>();
    }


    public void ShowDialogue(Dialogue dialogue)
    {
        for(int i = 0;i< dialogue.sentences.Length;i++)
        {
            listSentences.Add(dialogue.sentences[i]);
            listName.Add(dialogue.Name[i]);
            listDialogueWindows.Add(dialogue.dialogueWindows[i]);
        }
      //  animeDialogueWindow.SetBool("Appear", true);
        StartCoroutine(StartDialogueCoroutine());
    }


    public void ExitDialogue()
    {
        text.text = "";
        count = 0;
        listSentences.Clear();
        listName.Clear();
        listDialogueWindows.Clear();

        //animeDialogueWindow.SetBool("Appear", false);

    }

    IEnumerator StartDialogueCoroutine()
    {
        if(count>0)
        {
            if (listDialogueWindows[count] != listDialogueWindows[count - 1])
            {
            //    animeDialogueWindow.SetBool("appear", false);
                yield return new WaitForSeconds(0.1f);
                rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
                //animeDialogueWindow.SetBool("appear", true);
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
            }
        }
        else
        {
            rendererDialogueWindow.GetComponent<SpriteRenderer>().sprite = listDialogueWindows[count];
        }






        for (int i = 0; i < listSentences[count].Length;i++)
        {
            text.text += listSentences[count][i];
            text.text += listName[count][i];
               yield return new WaitForSeconds(0.01f);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) 
        {
        
            count++;
            text.text = "";

            if(count == listSentences.Count - 1)
            {
                StopAllCoroutines();
                ExitDialogue();
            }
            else
            {
                StopAllCoroutines();
                StartCoroutine(StartDialogueCoroutine());
            }
        }    
    }

}
