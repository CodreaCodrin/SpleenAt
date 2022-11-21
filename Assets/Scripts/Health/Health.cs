using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Health : MonoBehaviour
{
    [Header ("health")]
   [SerializeField] private float startingHealth;

    [Header("iFrames")]
    [SerializeField] private float iFramesD;
    private SpriteRenderer spriteRend;

    public float currentHeatlh { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHeatlh = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();    
    }

    public void TakeDamage(float _damage)
    {
        currentHeatlh = Mathf.Clamp(currentHeatlh - _damage, 0, startingHealth);
        
        if(currentHeatlh > 0)
        {
            StartCoroutine(Invunerability());
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("dead");

                //Player
                GetComponent<PlayerMovement>().enabled = false;

                dead = true;
            }
            
        }

    }

    public void AddHealth(float _value)
    {
        currentHeatlh = Mathf.Clamp(currentHeatlh + _value, 0, startingHealth);
    }

    private void Update()
    {
       
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        Physics2D.queriesStartInColliders = false;
        spriteRend.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(1.5f);
        spriteRend.color = Color.white;

        Physics2D.IgnoreLayerCollision(3, 6, false);
        Physics2D.queriesStartInColliders = true;
    }

}
