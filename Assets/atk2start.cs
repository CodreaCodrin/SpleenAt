using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atk2start : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void atk2true()
    {
        anim.SetBool("atk2", true);
    }

    public void atk2false()
    {
        anim.SetBool("atk2", false);
    }


}
