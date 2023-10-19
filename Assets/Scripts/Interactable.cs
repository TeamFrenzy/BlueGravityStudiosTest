using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact(Character character, GameObject target)
    {
        Debug.Log("Interacting!");
    }
}
