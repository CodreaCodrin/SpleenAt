using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUp : MonoBehaviour
{
    [SerializeField] private float healthValue;
    public GameObject me;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            
           if(collision.GetComponent<Health>().currentHeatlh <= 9)
            { 
                collision.GetComponent<Health>().AddHealth(healthValue);
                GameObject.Destroy(me);
            }

        }    
    }
}
