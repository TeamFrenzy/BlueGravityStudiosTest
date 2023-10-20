using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image itemIcon;
    [SerializeField] TextMeshProUGUI text;

    //Tooltip Parameters
    [SerializeField] GameObject tooltipPanel;
    [SerializeField] TextMeshProUGUI tooltipText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI priceText;

    //Options Parameters
    //[SerializeField] GameObject optionsPanel;

    int myIndex;

    InventoryPanel itemPanel;

    public void SetIndex(int index)
    {
        myIndex = index;
        if (itemPanel.inventory.slots[index] != null)
        {
            SetTooltip(index);
        }
    }

    private void SetTooltip(int index)
    {
        Item attachedItem = itemPanel.inventory.slots[index].item;
        tooltipPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(attachedItem.tooltipBoxSizeX, attachedItem.tooltipBoxSizeY);
        tooltipText.text = attachedItem.tooltip;
        nameText.text = attachedItem.itemName;

        //TODO: Add sell price if its in user inventory
        priceText.text = attachedItem.buyPrice.ToString();
    }

    public void SetItemPanel(InventoryPanel source)
    {
        itemPanel = source;
    }

    public void Set(ItemSlot slot)
    {
        Debug.Log("InSet");
        itemIcon.gameObject.SetActive(true);
        itemIcon.sprite = slot.item.icon;

        if(slot.item.isStackable == true )
        {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
        }
        else
        {
            text.gameObject.SetActive (false);
        }
    }

    public void Clean()
    {
        itemIcon.sprite = null;
        itemIcon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void ButtonTest()
    {
        Debug.Log("ButtonTest");
    }

    public void Activate()
    {
        if (itemPanel.inventory.slots[myIndex] != null)
        {
            if (itemPanel.isTrading)
            {
                if (itemPanel.inventory.slots[myIndex].item.isInStore)
                {
                    //Buy
                    Debug.Log("InBuying");
                    itemPanel.GetComponent<ItemStoreScript>().BuyItem(myIndex);
                }
                else if (!itemPanel.inventory.slots[myIndex].item.isInStore)
                {
                    //Sell
                    Debug.Log("InSelling");
                    itemPanel.mcTrading.SellItem(myIndex);
                    //itemPanel.Show();
                }
            }
            else if (!itemPanel.isTrading)
            {
                Debug.Log("InEquipping");
                Item itemToEquip = itemPanel.inventory.slots[myIndex].item;
                if (itemToEquip.isEquippable)
                {
                    Debug.Log("InEquippable");
                    Debug.Log(!itemToEquip.isEquipped);
                    if (!itemToEquip.isEquipped)
                    {
                        Debug.Log("InEquipped");
                        GameObject suitPrefab = Instantiate(itemToEquip.equipment, itemPanel.character.transform);
                        suitPrefab.GetComponent<MCAnimator>().mcController = itemPanel.character.GetComponent<MCController>();

                        if (itemToEquip.equipmentType == 0)
                        {
                            itemPanel.character.bodySlot = suitPrefab;
                        }
                        else if (itemToEquip.equipmentType == 1)
                        {
                            itemPanel.character.hatSlot = suitPrefab;
                        }
                        else if (itemToEquip.equipmentType == 2)
                        {
                            itemPanel.character.hairSlot = suitPrefab;
                        }
                        itemToEquip.isEquipped = true;
                    }
                    else if (itemToEquip.isEquipped)
                    {
                        Debug.Log("InUnEquipping");
                        if (itemToEquip.equipmentType == 0)
                        {
                            Destroy(itemPanel.character.bodySlot);
                        }
                        else if (itemToEquip.equipmentType == 1)
                        {
                            Destroy(itemPanel.character.hatSlot);
                        }
                        else if (itemToEquip.equipmentType == 2)
                        {
                            Destroy(itemPanel.character.hairSlot);
                        }
                        itemToEquip.isEquipped = false;
                    }
                }
                
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //optionsPanel.SetActive(true);
    }

    public void ShowTooltip()
    {
        tooltipPanel.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }
}
