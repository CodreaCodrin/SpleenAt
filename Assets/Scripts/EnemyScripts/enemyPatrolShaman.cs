using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyPatrolShaman : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform leftEdge;
    public Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;



    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;


    [Header("RUnAway Animator")]
    public bool run;
    public GameObject player;
    public bool flip;
    public float speedRun;
 
    private void Awake()
    {
        initScale = enemy.localScale;
        anim.SetBool("walk", true);
    }
    private void OnDisable()
    {
        anim.SetBool("walk", false);
     
    }
    public void RunTrue(bool a)
    {
        run = a;

    }
    private void Update()
    {
        Debug.Log(run);
        if (run == false)
        {
            anim.SetBool("walk", true);
            if (movingLeft)
            {

                if (enemy.position.x > leftEdge.position.x)
                    MoveInDirection(-1);
                else
                {
                    DirectionChange();
                }
            }
            else
            {
                if (enemy.position.x < rightEdge.position.x)
                    MoveInDirection(1);
                else
                {
                    DirectionChange();
                }
            }
        }

        else
        {
            RunFromPlayer();
        }

    }
     private void RunFromPlayer()
    {
        if (enemy.position.x > leftEdge.position.x && enemy.position.x < rightEdge.position.x && anim.GetBool("summon") == false)
        {
            
            if (player.transform.position.x < enemy.position.x)
         {
            enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -1 * (flip ? -1 : 1), initScale.y, initScale.z);
            enemy.position = new Vector3(enemy.position.x + Time.deltaTime * speedRun, enemy.position.y, enemy.position.z);
                movingLeft = false;
         }
         else
            {
            enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * (flip ? -1 : 1), initScale.y, initScale.z);
            enemy.position = new Vector3(enemy.position.x + Time.deltaTime * speedRun * - 1, enemy.position.y, enemy.position.z);
                movingLeft = true;
            }
        }
        else
        {
           
        }

    }

    private void DirectionChange()
    {
        anim.SetBool("walk", false);

        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
       
    }


    private void MoveInDirection(int _direction)
    {
        anim.SetBool("walk", true);
        idleTimer = 0;
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }
}
