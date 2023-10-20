using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPanel : MonoBehaviour
{
    public InventoryButton inventoryButton;

    public GameObject BuyGroup;
    public GameObject SellGroup;
    public GameObject EquipGroup;
    public GameObject UnequipGroup;

    GameObject groupcurrentlyOpen;

    public void BuyItem()
    {

    }

    public void Cancel()
    {
        groupcurrentlyOpen.SetActive(false);
        groupcurrentlyOpen = null;
    }

    public void OpenOrClose(bool open, GameObject group)
    {
        if (open)
        {
            groupcurrentlyOpen = group;
            group.SetActive(true);
        }
        else if (!open)
        {

            groupcurrentlyOpen = null;
            group.SetActive(false);
        }
    }
}
