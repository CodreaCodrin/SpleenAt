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
            eyeAttack eye = hitInfo.GetComponent<eyeAttack>();
            IgnoreShuriken shuriken = hitInfo.GetComponent<IgnoreShuriken>();
           
          if(enemy != null)
            {
                if (eye == null && shuriken ==null )
                    enemy.TakeDamage(1);
                else if(eye!=null) enemy.TakeDamage(100);
                
            }
            Destroy(gameObject);
        }
        
    }
}
