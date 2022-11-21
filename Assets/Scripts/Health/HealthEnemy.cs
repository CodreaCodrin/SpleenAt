using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [Header("health")]
    [SerializeField] private float startingHealth;

    public GameObject patrol;

    public float currentHeatlh { get; private set; }
    private Animator anim;
  

    private void Awake()
    {
        currentHeatlh = startingHealth;
        anim = GetComponent<Animator>();
       
    }

    public void TakeDamage(float _damage)
    {
        currentHeatlh = Mathf.Clamp(currentHeatlh - _damage, 0, startingHealth);

       
        if (currentHeatlh <= 0)
        {   
            anim.SetBool("dead", true);
            patrol.GetComponent<enemyPatrol>().enabled = false;
            patrol.GetComponentInChildren<MeleeEnemy>().enabled = false;
            
            
        }

    }

    private void Dead()
    {
        GameObject.Destroy(patrol);
    }
   

    private void Update()
    {

    }

   
}
