using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCInventoryController : MonoBehaviour
{
    [SerializeField] GameObject panel;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            panel.SetActive(!panel.activeInHierarchy);
        }
    }
}
