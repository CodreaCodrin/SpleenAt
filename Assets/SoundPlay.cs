using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{

    public AudioSource sunet;
    public void PlaySound()
    {
        sunet.PlayOneShot(sunet.clip);
    }
}
