using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeAttack : MonoBehaviour
{
    public GameObject bullet, bulletParent;
    public AudioSource sunet;
    public void attack()
    {
        
        Instantiate(bullet, bulletParent.transform.position, bulletParent.transform.rotation);
        sunet.PlayOneShot(sunet.clip);
    }

}
