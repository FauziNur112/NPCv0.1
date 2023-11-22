using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "NpcDialogue/AdvancedDialogueSO")]

public class AdvancedDialogueSO : ScriptableObject
{

    /*    public DialogueActors[] actors;*/

    [Tooltip("Only needed if random is selected as the actor name")]
    [Header("Random Actor Info")]
    public string randomActorName;
    public Sprite randomActorPortrait;

}
