using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPatrol : MonoBehaviour
{

    public GameObject patrol;
    public GameObject me;
    public float variabila;
    private Vector3 pozitie;


    void Start()
    {
        pozitie.y = variabila;
        pozitie.x = transform.position.x;
        pozitie.z = transform.position.z;
        StartCoroutine(waiter());
    }


    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(5f);
        GameObject newObject = Instantiate(patrol, pozitie, transform.rotation);
     
        yield return new WaitForSeconds(0.1f);
        Destroy(me);

    }
}

