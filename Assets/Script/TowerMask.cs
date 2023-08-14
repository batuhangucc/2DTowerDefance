using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMask : Tower
{

   
public void LoseHealth()
    {
        health--;
        if(health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
