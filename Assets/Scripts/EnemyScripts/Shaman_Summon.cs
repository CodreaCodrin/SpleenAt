using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shaman_Summon : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Summon Parameters")]
    public GameObject enemy1;
    public GameObject enemy2;
    private Vector3 pozitie;


    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;

    private enemyPatrolShaman enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<enemyPatrolShaman>();
        pozitie.y = 2.53f;
        pozitie.x = transform.position.x+5f;
        pozitie.z = transform.position.z;
     
    }

    public void DisableOnDead()
    {
        enemyPatrol.GetComponent<enemyPatrolShaman>().enabled = false;
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                
           
                StartCoroutine(waiter());

            }
           
     
        }
      

       // if (enemyPatrol != null)
          //  enemyPatrol.enabled = !PlayerInSight();
    }
    public bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void summon()
    {
        StartCoroutine(spawn());
    }

    IEnumerator waiter()
    {
        anim.SetBool("summon", true);
        yield return new WaitForSecondsRealtime(1.6f);

        anim.SetBool("summon", false);
        yield return new WaitForSeconds(0.1f);

    }

    IEnumerator spawn()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        GameObject newObject = Instantiate(enemy1, pozitie, transform.rotation);


        newObject.GetComponent<enemyPatrol>().player = enemyPatrol.GetComponent<enemyPatrolShaman>().player;
        newObject.GetComponent<enemyPatrol>().leftEdge = enemyPatrol.GetComponent<enemyPatrolShaman>().leftEdge;
        newObject.GetComponent<enemyPatrol>().rightEdge = enemyPatrol.GetComponent<enemyPatrolShaman>().rightEdge;

        pozitie.x = transform.position.x - 5f;
        newObject = Instantiate(enemy2, pozitie, transform.rotation);
        newObject.GetComponent<enemyPatrol>().player = enemyPatrol.GetComponent<enemyPatrolShaman>().player;
        newObject.GetComponent<enemyPatrol>().leftEdge = enemyPatrol.GetComponent<enemyPatrolShaman>().leftEdge;
        newObject.GetComponent<enemyPatrol>().rightEdge = enemyPatrol.GetComponent<enemyPatrolShaman>().rightEdge;
        yield return new WaitForSecondsRealtime(0.01f);
    }

}
