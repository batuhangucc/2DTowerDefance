using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public Spawner spawner;
    public CurrencySystem currencySystem;
    public HealthSystem healthSystem;   

    private void Start()
    {
        GetComponent<CurrencySystem>().Init();
    }
    IEnumerator WaweStartDelay()
    {
        yield return new WaitForSeconds(2f);
       
    }
}
