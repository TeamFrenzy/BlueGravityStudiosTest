using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MCTrading : MonoBehaviour
{
    [SerializeField] GameObject tradingScreen;
    [SerializeField] GameObject storePanel;
    [SerializeField] GameObject inventoryScreen;
    [SerializeField] ItemContainer playerInventory;
    [SerializeField] InventoryPanel inventoryPanel;

    Store store;
    MCCurrency money;
    ItemStoreScript itemStorePanel;

    private void Awake()
    {
        money = GetComponent<MCCurrency>();
        itemStorePanel = storePanel.GetComponent<ItemStoreScript>();
    }

    public void BeginTrading(Store store)
    {
        this.store = store;

        itemStorePanel.SetInventory(store.storeContent);
        tradingScreen.SetActive(true);
        inventoryScreen.SetActive(true);
    }

    public void StopTrading()
    {
        store = null;

        tradingScreen.SetActive(false);
        inventoryScreen.SetActive(false);
    }

    public void SellItem()
    {
        if (GameManager.Instance.dragAndDropController.CheckForSale() == true)
        {
            ItemSlot itemToSell = GameManager.Instance.dragAndDropController.itemSlot;
            int moneyGain = itemToSell.item.isStackable == true ? 
                (int)(itemToSell.item.price * itemToSell.count * store.buyFromPlayerMultip) :   
                (int)(itemToSell.item.price * store.sellToPlayerMultip);
            money.Add(moneyGain);
            itemToSell.Clear();
        }
    }

    internal void BuyItem(int id)
    {
        Item itemToBuy = store.storeContent.slots[id].item;
        int totalPrice = (int)(itemToBuy.price * store.sellToPlayerMultip);
        if (money.Check(totalPrice) == true)
        {
            money.Decrease(totalPrice);
            playerInventory.Add(itemToBuy);
            inventoryPanel.Show();
        }

    }
}
