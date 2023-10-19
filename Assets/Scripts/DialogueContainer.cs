using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Dialogue/Container")]
public class DialogueContainer : ScriptableObject
{
    public List<string> line;
    public Actor actor;

}
