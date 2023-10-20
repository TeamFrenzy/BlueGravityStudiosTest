using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor.Search;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;

public class InventoryPanel : MonoBehaviour
{
    public ItemContainer inventory;
    public List<InventoryButton> buttons;
    public MCTrading mcTrading;
    public Character character;

    public bool isStore;
    public bool isTrading;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SetSourcePanel();
        SetIndex();
        if(isStore)
        {
            SetIsInStore();
        }
        Show();
    }

    private void SetSourcePanel()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetItemPanel(this);
        }
    }

    private void SetIsInStore()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            inventory.slots[i].item.isInStore = true;
            Debug.Log("Item " + inventory.slots[i].item.itemName + "isInStore?:" + inventory.slots[i].item.isInStore);
        }
    }

    private void OnEnable()
    {
        Clear();
        Show();
    }

    private void LateUpdate()
    {
        if (inventory== null)
        {
            return;
        }
    }

    private void SetIndex()
    {
        for(int i = 0; i < inventory.slots.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    public void Show()
    {
        if (inventory == null) { return; }

        for(int i =0; i< inventory.slots.Count; i++)
        {
            if (inventory.slots[i].item == null )
            {
                buttons[i].Clean();
            }
            else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }
    public void SetInventory(ItemContainer newInventory)
    {
        inventory = newInventory;
    }

    public void Clear()
    {
        for(int i =0; i< buttons.Count;i++)
        {
            buttons[i].Clean();
        }
    }

    public virtual void OnClick(int id)
    {
        Debug.Log("OnClockInventoryPanelCalled!");
    }
}
