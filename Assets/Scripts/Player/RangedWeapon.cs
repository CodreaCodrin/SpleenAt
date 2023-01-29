using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shurikenPrefab;

    public int Inventory = 3;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime && Inventory > 0)
        {
            if (Input.GetButtonDown("FireRanged"))
            {
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
                Inventory--;
            }
        }
    }

    void Shoot ()
    {
        Instantiate(shurikenPrefab, firePoint.position, firePoint.rotation);
    }

    public void AddShuriken (int howmuch)
    {
        Inventory = Inventory + howmuch;
    }
}
