using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject playerCharacter;
    public ItemContainer inventaryContainer;
    public DragAndDropController dragAndDropController;
    public DialogueSystem dialogueSystem;

    private void Awake()
    {
        Instance = this;
    }


}
