using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    [SerializeField] private DialogueContainer dialogue;   
    public override void Interact(Character character)
    {
        GameManager.Instance.dialogueSystem.Initialize(dialogue);
    }
}
