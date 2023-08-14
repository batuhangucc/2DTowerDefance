using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    public Text currencyText;
    public int defaultCurrency;
    public int currency;
    public void Init()
    {
        currency = defaultCurrency;
        UpdateUI();
        
    }
    public void Gain(int val)
    {
        currency += val;
        UpdateUI() ;    
    }
    public bool Use(int val)
    {
        if(EnoughCurrency(val)) 
        {
            currency -= val;
            UpdateUI () ;
            return true;
        }
        else
        {
            return false;
        }
    }
   public bool EnoughCurrency(int val)
    {
        if (val<=currency)
        {
            return true;
        }
        else
            return false;
    }
    void UpdateUI()
    {
        currencyText.text = currency.ToString();
    }
    
}
