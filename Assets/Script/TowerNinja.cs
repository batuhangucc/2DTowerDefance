using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNinja : Tower
{
    
    public int damage;
    public GameObject prefab_shootItem;
    public float interval; 
    void Start()
    {
        StartCoroutine(ShootDelay());
    }
    IEnumerator ShootDelay()
    {
       while (true) 
        {
            yield return new WaitForSeconds(interval);
            Shootitem();
        }
    }
    public void LoseHealth()
    {
        if (health <=0)
        {
            Die();
        }
    }
    void Shootitem()
    {
        GameObject shotItem=Instantiate(prefab_shootItem,transform);
        shotItem.GetComponent<ShootItem>().Init(damage);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
