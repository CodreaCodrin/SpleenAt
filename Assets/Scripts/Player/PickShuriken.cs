using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickShuriken : MonoBehaviour
{
    [SerializeField] private int Value;
    public GameObject me;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<RangedWeapon>().AddShuriken(Value);
            GameObject.Destroy(me);
        }
    }
}
