using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : Interactable
{
    public ItemContainer storeContent;

    public float buyFromPlayerMultip = 0.5f;
    public float sellToPlayerMultip = 1.5f;

    public override void Interact(Character character)
    {
        MCTrading trading = character.GetComponent<MCTrading>();

        if(trading == null ) { return; }

        trading.BeginTrading(this);
    }
}
