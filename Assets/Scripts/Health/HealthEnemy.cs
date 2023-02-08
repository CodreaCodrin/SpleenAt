using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [Header("health")]
    [SerializeField] private float startingHealth;

    public GameObject patrol;
    public GameObject life;
    public GameObject shuriken;


    public float currentHeatlh { get; private set; }
    private Animator anim;

    public SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHeatlh = startingHealth;
        anim = GetComponent<Animator>();
       
    }
    private void SpawnOject()
    {
        float randomNumber = Random.Range(1, 100);
        if(randomNumber > 70)
        {
           GameObject newObject = Instantiate(life,transform.position,transform.rotation);
        }
        else if(randomNumber >30)
        {
           GameObject newObject = Instantiate(shuriken, transform.position, transform.rotation);
        }
       
    }

    public void TakeDamage(float _damage)
    {
        currentHeatlh = Mathf.Clamp(currentHeatlh - _damage, 0, startingHealth);
       

        if (currentHeatlh <= 0)
        {
           
            anim.SetBool("dead", true);
            if(patrol.GetComponent<EyePatrol>() != null) patrol.GetComponent<EyePatrol>().enabled =false;
            if (patrol.GetComponent<enemyPatrol>() != null) patrol.GetComponent<enemyPatrol>().enabled = false;
            if (patrol.GetComponent<Shaman_Summon>() != null) patrol.GetComponent<Shaman_Summon>().enabled = false;
            if (patrol.GetComponent<MeleeEnemy>() != null) patrol.GetComponent<MeleeEnemy>().enabled = false;
            if (patrol.GetComponent<CioaraPatrol>() != null) patrol.GetComponent<CioaraPatrol>().enabled = false;
           
            
            
        }
        else
        {
             StartCoroutine(TakeDamageAnim());
        }

    }

    private void Dead()
    {
        GameObject.Destroy(patrol);
    }

    private IEnumerator TakeDamageAnim()
    {
        spriteRend.color = new Color(4.5f, 0, 0, 1.0f);
        yield return new WaitForSeconds(0.3f);
        spriteRend.color = Color.white;
    }
}
