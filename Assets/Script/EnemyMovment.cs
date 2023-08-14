using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    // Start is called before the first frame update
    public int health, attackPower;
    public float moveSpeed;
    public float attackInterval;
    Coroutine attackOrder;
    Tower detectedTower;
    public int count = 5;
    private void Update()
    {
        if (!detectedTower)
        {
            Move();
        }
    }
    void Move()
    {
        transform.Translate(-transform.right*moveSpeed*Time.deltaTime);

    }
    IEnumerator Attack ()
    {
        yield return new WaitForSeconds(attackInterval);
        InflictDamage();
        attackOrder =StartCoroutine(Attack());
    }
   public void LoseHealth()
    {
        health--;
        StartCoroutine(TurnRed());
        if (health <=0)
            Destroy(gameObject);

    }
    public void InflictDamage()
    {
        if (!detectedTower)
            return;
        bool towerDied = detectedTower.LoseHealth(attackPower);
        if (towerDied)
        {
            detectedTower = null;
            StopCoroutine(attackOrder);
        }
    }


    IEnumerator TurnRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (detectedTower)
            return;

        if (collision.tag == "Tower")
        {
            detectedTower = collision.GetComponent<Tower>();
            attackOrder = StartCoroutine(Attack());
        }
        if (collision.tag == "Health")
        {
            Destroy(gameObject);
        }





    }
}
