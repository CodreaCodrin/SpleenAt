using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    private void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized* speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
      
    }

        private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player" || hitInfo.gameObject.tag == "WorldBorder")
        {
            Health player = hitInfo.GetComponent<Health>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
            Destroy(gameObject);
        }

    }
}
