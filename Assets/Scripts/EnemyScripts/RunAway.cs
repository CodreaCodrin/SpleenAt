using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunAway : MonoBehaviour
{

    public GameObject enemy;

    private bool hit;


    private void Update()
    {
       
            enemy.GetComponent<enemyPatrolShaman>().RunTrue(hit);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hit = false;

        }
    }

}


    