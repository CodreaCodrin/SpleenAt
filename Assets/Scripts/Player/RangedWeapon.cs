using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class RangedWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shurikenPrefab,textGameObject;
    private TMP_Text text;

    public int Inventory = 3, limit = 4;
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
                text.text = Inventory.ToString();
            }
        }
    }

    void Shoot ()
    {
        Instantiate(shurikenPrefab, firePoint.position, firePoint.rotation);
    }

    public void AddShuriken (int howmuch)
    {
        if (Inventory < limit)
        {
            Inventory = Inventory + howmuch;
            text.text = Inventory.ToString();
        }
    }

    private void Start()
    {
        text = textGameObject.GetComponent<TMP_Text>();
        text.text = "3";
    }
}
