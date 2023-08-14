using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPink : Tower
{
    
    public int incomeValue;
    public float interval;
   
    
    void Start()
    {
    }
    IEnumerator Interval()
    {
        yield return new WaitForSeconds(interval);
        IncreaseIncome();
        StartCoroutine(Interval());

    }
    public void IncreaseIncome()
    {
        GameManager.Instance.currencySystem.Gain(incomeValue);
        StartCoroutine(CoinIndication());
    }
    IEnumerator CoinIndication()
    {
        yield return new WaitForSeconds(5.0f);
        
    }
    public void LoseHealth()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }
       
    public void Die()
    {

        Debug.Log("Tower is dead");
        Destroy(gameObject);

    }
}
