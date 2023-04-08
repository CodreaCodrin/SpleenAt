using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [Header("health")]
    [SerializeField] private float startingHealth;

    [Header("iFrames")]
    [SerializeField] private float iFramesD;
    private SpriteRenderer spriteRend;

    private Animator anim;
    private bool deadstate;
    public float currentHeatlh { get; private set; }

    [Header("Record Wave")]
    public int record;
    public TMP_Text recordText;

    [Header("GameObj ref.")]
    public GameObject cam;
    public GameObject groundCheck;
    public GameObject wave;
    public List<GameObject> Lifes = new List<GameObject>();
    public GameObject buttons;
    public GameObject RecordText;
  

    private void Awake()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Physics2D.IgnoreLayerCollision(3, 6, false);
        Physics2D.IgnoreLayerCollision(3, 7, false);
        Physics2D.queriesStartInColliders = true;
        if (data!= null) record = data.record; 
        GetComponent<CapsuleCollider2D>().sharedMaterial.friction = 0;
        cam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 5f;
        currentHeatlh = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(3, 9, true);
        recordText.text = "Record Wave " + record.ToString();
    }

    public void TakeDamage(float _damage)
    {
        currentHeatlh = Mathf.Clamp(currentHeatlh - _damage, 0, startingHealth);

        int health = (int)currentHeatlh;
        Animator life = Lifes[health].GetComponent<Animator>();
        life.SetTrigger("Lose");
       

        if (currentHeatlh > 0)
        {
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!deadstate)
            {
                GetComponent<CapsuleCollider2D>().sharedMaterial.friction = 100;
                deadstate = true;
                Vector2 location = new Vector2(-0.31f, 0.1f);
                GetComponent<CapsuleCollider2D>().offset = location;
                anim.SetBool("dead", true);
                Physics2D.IgnoreLayerCollision(3, 6, true);
                Physics2D.IgnoreLayerCollision(3, 7, true);
                Physics2D.queriesStartInColliders = false;
                GetComponent<PlayerCombat>().enabled = false;
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<RangedWeapon>().enabled = false;
            }
        }
    }

    public void AddHealth(float _value)
    {   
     
        int health = (int)currentHeatlh;
        Animator life = Lifes[health].GetComponent<Animator>();
        life.SetTrigger("Add");
       

        currentHeatlh = Mathf.Clamp(currentHeatlh + _value, 0, startingHealth);
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        Physics2D.IgnoreLayerCollision(3, 7, true);
        Physics2D.queriesStartInColliders = false;

        spriteRend.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(1.5f);
        spriteRend.color = Color.white;

        Physics2D.IgnoreLayerCollision(3, 6, false); Physics2D.IgnoreLayerCollision(3, 7, false);
        Physics2D.queriesStartInColliders = true;
    }

  
    public void Dead()
    {
        int newrecord = wave.GetComponent<WaveSpawner>().ThisWave - 1;
        if(newrecord >= record) 
            { record =newrecord;
            SaveSystem.SaveRecord(this);
        }
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Zoom()
    {
        cam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 2.5f;
        cam.GetComponent<CinemachineVirtualCamera>().m_Follow = groundCheck.transform;
        
    }

    public void buttonsActive()
    {
        buttons.SetActive(true);
        RecordText.SetActive(false);
    }
}
