using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeChase : MonoBehaviour
{
    public GameObject enemy;

    private bool hit;

    private void Update()
    {
        enemy.GetComponentInParent<EyePatrol>().RunTrue(hit);
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
