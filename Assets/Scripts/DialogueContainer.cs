using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Dialogue/Container")]
public class DialogueContainer : ScriptableObject
{
    public List<string> textLine;
    public List<int> textSize;
    public List<int> windowWidthSize;
    public List<int> windowHeightSize;
    public string actorName;
    public Vector2 position;
    public bool isTalking;
    public AudioClip talkingClip;
    public bool isShop;

}
