using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUp : MonoBehaviour
{
    [SerializeField] private float healthValue;
    public GameObject eu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthValue);
            GameObject.Destroy(eu);

        }    
    }
}
