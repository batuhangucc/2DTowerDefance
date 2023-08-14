using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootItem : MonoBehaviour
{
    public Transform graphics;
    public int damage;
    public float flyspeed,rotateSpeed;
    public LayerMask enemyLayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        FlyForward();
    }
    public void Init(int dmg)
    {
        damage = dmg;   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag==("Enemy")) 
        {
            collision.GetComponent<EnemyMovment>().LoseHealth();
            Destroy(this.gameObject);
        }
        if (collision.tag == ("Limit"))
        {
            Destroy(this.gameObject);
            
        }
    }
    private void Rotate()
    {
        graphics.Rotate(new Vector3(0, 0, -rotateSpeed*Time.deltaTime));
    }
    void FlyForward()
    {
        transform.Translate(transform.right*flyspeed*Time.deltaTime);
    }
}
