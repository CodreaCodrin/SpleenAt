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
    float nextAttackTime = 0f;

    public int AttackBrowser = 1;
    public float ComboWindow = 1f;

    public AudioSource sunet1,sunet2,sunet3;


    private void Start()
    {
    }    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if (animator.GetBool("IsJumping") == false)
                {
                    Attack(AttackBrowser);
                    if (AttackBrowser != 3)
                        AttackBrowser = AttackBrowser + 1;
                    else
                        AttackBrowser = 1;
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }

        if (Time.time >= nextAttackTime + 1f / ComboWindow)
        {
            AttackBrowser = 1;
        }

        if (AttackBrowser > 1)
            animator.SetBool("IsInCombo", true);
        else
            animator.SetBool("IsInCombo", false);
    }

    void Attack(int WhichAttack)
    {
        if (WhichAttack == 1)
        {
            sunet1.PlayOneShot(sunet1.clip);
      
        }

        if (WhichAttack == 2)
        {
            sunet2.PlayOneShot(sunet2.clip);
        
        }

        if (WhichAttack == 3)
        {
            sunet3.PlayOneShot(sunet3.clip);
        }

        if (WhichAttack == 1)
            animator.SetTrigger("Attack");
        if(WhichAttack == 2)
            animator.SetTrigger("Attack2");
        if(WhichAttack == 3)
            animator.SetTrigger("Attack3");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            if(WhichAttack != 3)
                enemy.GetComponent<HealthEnemy>().TakeDamage(1);
            else
                enemy.GetComponent<HealthEnemy>().TakeDamage(2);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return; 

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    
   
}
