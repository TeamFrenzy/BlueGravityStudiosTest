using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    [SerializeField] private DialogueContainer[] dialogue;
    [SerializeField] private DialogueContainer exitDialogue;

    public int currentDialogue = 0;
    public override void Interact(Character character, GameObject target)
    {
        character.mcController.canMove = false;
        GameManager.Instance.dialogueSystem.Initialize(dialogue[currentDialogue], target);
        if(currentDialogue < dialogue.Length-1) { currentDialogue++; }
    }

    public void PlayExitDialogue(Character character, GameObject target)
    {
        character.mcController.canMove = false;
        GameManager.Instance.dialogueSystem.Initialize(exitDialogue, target);
    }
}
