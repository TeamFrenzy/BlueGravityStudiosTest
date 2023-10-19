using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MCCurrency : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] int startAmount = 1200;
    [SerializeField] TextMeshProUGUI text;

    internal void Add(int moneyGain)
    {
        amount += moneyGain;
        UpdateText();
    }

    internal bool Check(int totalPrice)
    {
        return amount >= totalPrice;
    }

    internal void Decrease(int totalPrice)
    {
        amount -= totalPrice;
        if(amount < 0)
        {
            amount = 0;
        }
        UpdateText();
    }

    private void Start()
    {
        amount = startAmount;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = amount.ToString();
    }

}
