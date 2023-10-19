using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCInventoryController : MonoBehaviour
{
    [SerializeField] GameObject inventoryScreen;
    [SerializeField] GameObject tradingScreen;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(inventoryScreen.activeInHierarchy == false)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }

    public void Open()
    {
        inventoryScreen.SetActive(true);
        tradingScreen.SetActive(false);
    }

    public void Close()
    {
        inventoryScreen.SetActive (false);
        tradingScreen.SetActive(false);
    }
}
