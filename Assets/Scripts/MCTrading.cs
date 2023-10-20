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
    [SerializeField] InventoryPanel storeInventoryPanel;

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
        inventoryPanel.isTrading = true;
    }

    public void StopTrading()
    {
        tradingScreen.SetActive(false);
        inventoryScreen.SetActive(false);
        if (store.HasExitDialogue)
        {
            store.gameObject.GetComponent<DialogueInteractable>().PlayExitDialogue(GetComponent<Character>(), store.gameObject);
        }
        inventoryPanel.isTrading = false;
        store = null;
    }

    /*
    public void SellItem()
    {
        ItemSlot itemToSell = GameManager.Instance.dragAndDropController.itemSlot;
        int moneyGain = itemToSell.item.isStackable == true ?
            (int)(itemToSell.item.sellPrice * itemToSell.count * store.buyFromPlayerMultip) :
            (int)(itemToSell.item.sellPrice * store.sellToPlayerMultip);
        money.Add(moneyGain);
        itemToSell.Clear();
    }
    */

    public void SellItem(int id)
    {
        ItemSlot itemToSell = inventoryPanel.inventory.slots[id];
        int moneyGain = itemToSell.item.isStackable == true ?
            (int)(itemToSell.item.sellPrice * itemToSell.count * store.buyFromPlayerMultip) :
            (int)(itemToSell.item.sellPrice * store.sellToPlayerMultip);
        money.Add(moneyGain);
        itemToSell.Clear();
        inventoryPanel.Show();
    }

    internal void BuyItem(int id)
    {
        Item itemToBuy = store.storeContent.slots[id].item;
        int totalPrice = (int)(itemToBuy.buyPrice * store.sellToPlayerMultip);
        if (money.Check(totalPrice) == true)
        {
            store.storeContent.slots[id].item.isInStore = false;
            money.Decrease(totalPrice);
            playerInventory.Add(itemToBuy);
            store.storeContent.slots[id].Clear();
            storeInventoryPanel.Show();
            inventoryPanel.Show();
        }

    }
}
