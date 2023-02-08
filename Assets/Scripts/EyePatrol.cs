using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EyePatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform leftEdge;
    public Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed1, speed2;
    private Vector3 initScale;
    private Vector2 up;
    private bool movingLeft;


    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;


    [Header("cHASE Animator")]
    public bool run, poz;
    public GameObject player;
    public bool flip;

    [Header("Shooting")]
    public float shootingRange;
    

    private void Awake()
    {
        initScale = enemy.localScale;
        up.y = 4.55f;


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
        float distance = Vector2.Distance(player.transform.position,transform.position);
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
            if (run == true && distance > shootingRange)
            {
                anim.SetBool("attack", false);
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
            else if(poz == false && run ==false)
            {
                anim.SetBool("attack", false);
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
            else if(run == true && distance <= shootingRange && player.GetComponent<Health>().currentHeatlh > 0)
            {
                anim.SetBool("attack", true);
                
                if (player.transform.position.x < enemy.position.x)
                {
                    enemy.localScale = new Vector3(Mathf.Abs(initScale.x)  * -1* (flip ? -1 : 1), initScale.y, initScale.z);

                }
                else
                {
                    enemy.localScale = new Vector3(Mathf.Abs(initScale.x)  * (flip ? -1 : 1), initScale.y, initScale.z);

                }
                if (math.abs(player.transform.position.x - enemy.position.x)<= 2.5f) transform.position = Vector2.MoveTowards(this.transform.position, new Vector2( player.transform.position.x * -1,player.transform.position.y), speed2 * Time.deltaTime);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    

}
