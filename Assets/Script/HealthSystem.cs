using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Text healthTextt;
    public int defaulHealthCount;
    public int healthCount;

    public void Init()
    {
        healthCount = defaulHealthCount;
        healthTextt.text = healthCount.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            healthCount--;
            healthTextt.text = healthCount.ToString();
            CheckHealthCount();
        }
    }
    
    void CheckHealthCount()
    {
        if (healthCount ==  0)
        {
            Time.timeScale = 0f;
        }
 
    }
}
