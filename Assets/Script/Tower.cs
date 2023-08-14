using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int health;
    public int cost;
    private Vector3Int cellposition;
   

    protected virtual void Start()
    {
        Debug.Log("Base Tower");
    }
    public virtual void Init(Vector3Int cellPos)
    {
        cellposition = cellPos;
    }
    public virtual bool LoseHealth(int amount)
    {
        //health = health - amou
        health -= amount;
        StartCoroutine(TurnRed());
        if (health <= 0)
        {
            
            Die();
            return true;
        }
        return false;
    }
    IEnumerator TurnRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    protected virtual void Die()
    {
        Debug.Log("Tower is dead");
        FindObjectOfType<Spawner>().RevertCellState(cellposition);
        Destroy(gameObject);
    }
}
