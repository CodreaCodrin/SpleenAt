using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CioaraPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform leftEdge;
    public Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed1,speed2;
    private Vector3 initScale;
    private Vector2 up;
    private bool movingLeft;


    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;


    [Header("cHASE Animator")]
    public bool run,poz;
    public GameObject player;
    public bool flip;

    private void Awake()
    {
        initScale = enemy.localScale;
        up.y = 4.55f;

        poz = (transform.position.y == up.y);

        player = GameObject.FindGameObjectWithTag("Player");
        leftEdge = GameObject.FindGameObjectWithTag("Leftedge").transform;
        rightEdge = GameObject.FindGameObjectWithTag("RightEdge").transform;
    }


    private void OnDisable()
    {
     
    }

    public void RunTrue(bool a)
    {
        run = a;

    }
    private void Update()
    {
        up.x = enemy.localScale.x;
        if (run == false && poz == true)
        {
            enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -1 * (movingLeft ? -1 : 1), initScale.y, initScale.z);
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
            if (run == true)
            {
                poz = false;
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed2 * Time.deltaTime);
                if (player.transform.position.x < enemy.position.x)
                {
                    enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -1 * (flip ? -1 : 1), initScale.y, initScale.z);
                    
                }
                else
                {
                    enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * (flip ? -1 : 1), initScale.y, initScale.z);
                   
                }

            }
            else 
            {
                if (transform.position.y != up.y)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, up, speed1 * Time.deltaTime);
                    if (up.x < enemy.position.x)
                    {
                        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * -1 * (flip ? -1 : 1), initScale.y, initScale.z);

                    }
                    else
                    {
                        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * (flip ? -1 : 1), initScale.y, initScale.z);

                    }
                }
                else
                {
                    poz = true;
                }

            }
        }

    }

    private void DirectionChange()
    {

        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }


    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed1, enemy.position.y, enemy.position.z);
    }


}
