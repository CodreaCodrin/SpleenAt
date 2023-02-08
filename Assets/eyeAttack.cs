using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeAttack : MonoBehaviour
{
    public GameObject bullet, bulletParent;
    public void attack()
    {
        
        Instantiate(bullet, bulletParent.transform.position, bulletParent.transform.rotation);
    }

}
