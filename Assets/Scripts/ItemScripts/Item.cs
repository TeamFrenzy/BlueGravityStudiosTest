using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public bool isStackable;
    public Sprite icon;
    public Sprite worldSprite;
    public string tooltip = "Here be a little tooltip";
    public float tooltipBoxSizeX;
    public float tooltipBoxSizeY;
    public int buyPrice = 200;
    public int sellPrice = 100;
    public bool canBeSold = true;
    public bool isInStore = false;
    public bool isEquippable;
    public bool isEquipped;
    public GameObject equipment;
    public int equipmentType;

}
