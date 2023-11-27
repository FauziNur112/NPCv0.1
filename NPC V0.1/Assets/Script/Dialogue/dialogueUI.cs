using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class dialogueUI : MonoBehaviour
{
 public GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private ResponseHandler responseHendler;
    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHendler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
        ShowDialogue(testDialogue);
    }


    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }
    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {

        for(int i =0; i<dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if(dialogueObject.HasResponses)
        {
            responseHendler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();

        }
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

}
