using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;  
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;


    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;

    private Health playerHealth;

    private enemyPatrol enemyPatrol;



    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<enemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer +=Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetBool("attack" , true);
            }
        }
        else anim.SetBool("attack", false);

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }
    public bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0 ,playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void DamagePlayer()
    {
        if(PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
