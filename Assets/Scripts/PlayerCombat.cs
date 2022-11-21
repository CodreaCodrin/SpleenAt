using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
             if(Input.GetKeyDown(KeyCode.E))
                    {
                        Attack();
                nextAttackTime = Time.time + 1f / attackRange;
                    }
        }
       
       
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HealthEnemy>().TakeDamage(1);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return; 

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
