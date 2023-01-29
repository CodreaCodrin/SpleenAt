using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.gameObject.tag != "Ignore_Range")
        {
            HealthEnemy enemy = hitInfo.GetComponent<HealthEnemy>();
            if(enemy != null)
            {
                 enemy.TakeDamage(1);
            }
            Destroy(gameObject);
        }
        
    }
}
