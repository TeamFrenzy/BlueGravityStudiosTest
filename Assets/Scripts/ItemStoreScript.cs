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

        if (GameManager.Instance.dragAndDropController.itemSlot.item == null)
        {
            BuyItem(id);
        }
        else
        {
            SellItem();
        }

        Show();
    }

    private void BuyItem(int id)
    {
        trading.BuyItem(id);
    }

    private void SellItem()
    {
        trading.SellItem();
    }
}
