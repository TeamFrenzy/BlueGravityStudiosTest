using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ItemStoreScript : InventoryPanel
{
    [SerializeField] MCTrading trading;
    public override void OnClick(int id)
    {
        Debug.Log("OnClickCalled!");
        BuyItem(id);
        /*
        if (GameManager.Instance.dragAndDropController.itemSlot.item == null)
        {
            BuyItem(id);
        }
        else
        {
            SellItem();
        }
        */
        Show();
    }

    public void BuyItem(int id)
    {
        trading.BuyItem(id);
    }

    /*
    public void SellItem(int id)
    {
        trading.SellItem();
    }
    */
}
