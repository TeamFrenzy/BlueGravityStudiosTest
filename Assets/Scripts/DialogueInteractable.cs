using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable
{
    [SerializeField] private DialogueContainer dialogue;   
    public override void Interact(Character character, GameObject target)
    {
        character.mcController.canMove = false;
        GameManager.Instance.dialogueSystem.Initialize(dialogue, target);
    }
}
