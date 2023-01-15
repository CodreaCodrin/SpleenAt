using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEditor.Experimental;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
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


    [Header("cHASE Animator")]
    public bool run;
    public GameObject player;
    public bool flip;
    public float speedRun;

    private void Awake()
    {
        initScale = enemy.localScale;
    }


    private void OnDisable()
    {
        anim.SetBool("walk", false);
        anim.SetBool("run", false);
    }

    public void RunTrue(bool a)
    {
        run = a;
        
    }
    private void Update()
    {
        if(run == false)
        {
            if (movingLeft)
            {
            
              if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
                 else
                 {
                DirectionChange();
                 }
             }
            else 
             {
                 if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
                 else
                 {
                DirectionChange();
                 }
            }
        }
        
        else
        {
            FollowPlayer();
        }

    }


    private void FollowPlayer()
    {
        anim.SetBool("walk", false);
        anim.SetBool("run", true);
        



        if (player.transform.position.x < enemy.position.x)
        {
            enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -1 * (flip ? -1 : 1), initScale.y, initScale.z);
            enemy.position = new Vector3(enemy.position.x + Time.deltaTime * speedRun*-1, enemy.position.y, enemy.position.z);
        }
        else
        {
            enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * (flip ? -1 : 1), initScale.y, initScale.z);
            enemy.position = new Vector3(enemy.position.x + Time.deltaTime * speedRun, enemy.position.y, enemy.position.z);
        }


    }

    private void DirectionChange()
    {

        anim.SetBool("walk", false);

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration) 
        movingLeft = !movingLeft;
    }


    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("run", false);
        anim.SetBool("walk", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,enemy.position.y,enemy.position.z);
    }
}
