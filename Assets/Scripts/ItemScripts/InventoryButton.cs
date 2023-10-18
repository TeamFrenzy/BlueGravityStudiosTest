using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image itemIcon;
    [SerializeField] TextMeshProUGUI text;

    int myIndex;

    public void SetIndex(int index)
    {
        myIndex = index;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemContainer inventory = GameManager.Instance.inventaryContainer;
        GameManager.Instance.dragAndDropController.OnClick(inventory.slots[myIndex]);
        transform.parent.GetComponent<InventoryPanel>().Show();
    }
}
