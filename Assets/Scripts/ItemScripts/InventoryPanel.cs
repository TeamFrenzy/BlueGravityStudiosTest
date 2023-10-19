using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor.Search;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;
    [SerializeField] List<InventoryButton> buttons;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SetSourcePanel();
        SetIndex();
        Show();
    }

    private void SetSourcePanel()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetItemPanel(this);
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
        /*
        if(inventory.isDirty)
        {
            Show();
            inventory.isDirty = false;
        }
        */
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

    }
}
