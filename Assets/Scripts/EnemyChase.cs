using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{

    public GameObject enemy;
  
    private bool lovit;


    private void Update()
    {
        if (lovit == true)
        {
            enemy.GetComponent<enemyPatrol>().RunTrue(true);
           
        }
        else enemy.GetComponent<enemyPatrol>().RunTrue(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            lovit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            lovit = false;
  
        }
    }
    
}
