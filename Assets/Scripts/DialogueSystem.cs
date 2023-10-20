using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vCam;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] Character character;
    [SerializeField] TextMeshProUGUI targetText;
    [SerializeField] TextMeshProUGUI nameText;

    DialogueContainer currentDialogue;
    GameObject currentTarget;
    int currentTextLine;

    [Range(0f, 1f)]
    [SerializeField] float visibleTextPercent;
    [SerializeField] float timePerLetter = 0.75f;
    float totalTimeToType, currentTime;
    string lineToShow;

    [SerializeField]float timeUntilClipTotal = 0.75f;
    float timeUntilClipCurrent;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            PushText();
        }
        TypeOutText();
    }

    public void Initialize(DialogueContainer dialogueContainer, GameObject target)
    {
        currentTarget = target;
        vCam.m_Follow = target.transform;
        dialoguePanel.GetComponent<RectTransform>().sizeDelta = new Vector2(dialogueContainer.windowHeightSize[0], dialogueContainer.windowHeightSize[0]);
        targetText.fontSize = dialogueContainer.textSize[0];
        dialoguePanel.transform.position = dialogueContainer.position;
        Show(true);
        currentDialogue = dialogueContainer;
        currentTextLine = 0;
        CycleLine();
        nameText.text = currentDialogue.actorName;
    }

    private void TypeOutText()
    {
        if (visibleTextPercent >= 1f) { return; }
        currentTime += Time.deltaTime;
        timeUntilClipCurrent += Time.deltaTime;
        visibleTextPercent = currentTime / totalTimeToType;
        visibleTextPercent = Mathf.Clamp(visibleTextPercent, 0f, 1f);
        UpdateText();
    }

    void UpdateText()
    {
        int letterCount = (int)(lineToShow.Length * visibleTextPercent);
        targetText.text = lineToShow.Substring(0, letterCount);
        if(currentDialogue.isTalking && timeUntilClipCurrent > timeUntilClipTotal)
        {
            character.GetComponent<AudioSource>().PlayOneShot(currentDialogue.talkingClip);
            timeUntilClipCurrent = 0f;
        }
    }

    //Ensures that the full line is displayed before skipping to the next one.
    private void PushText()
    {
        if(visibleTextPercent <1f)
        {
            visibleTextPercent = 1f;
            UpdateText();
            return;
        }

        if(currentTextLine >= currentDialogue.textLine.Count) 
        {
            Conclude();
        }
        else
        {
            CycleLine();
        }
    }

    void CycleLine()
    {
        lineToShow = currentDialogue.textLine[currentTextLine];
        totalTimeToType = lineToShow.Length * timePerLetter;
        currentTime = 0f;
        visibleTextPercent = 0f;
        targetText.text = "";

        dialoguePanel.GetComponent<RectTransform>().sizeDelta = new Vector2(currentDialogue.windowWidthSize[currentTextLine], currentDialogue.windowHeightSize[currentTextLine]);
        targetText.fontSize = currentDialogue.textSize[currentTextLine];

        currentTextLine += 1;
    }

    private void Show(bool v)
    {
        gameObject.SetActive(v);
    }

    private void Conclude()
    {
        Debug.Log("Dialogue has ended");
        Show(false);
        vCam.m_Follow = character.transform;
        if(currentDialogue.isShop)
        {
            currentTarget.GetComponent<Store>().Interact(character, currentTarget);
        }
        else
        {
            character.mcController.canMove = true;
        }
    }
}
