using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPatrol : MonoBehaviour
{

    public GameObject patrol;
    public GameObject me;
    private Vector3 pozitie;
    public GameObject Player;
    public GameObject Re;
    public GameObject Le;

    void Start()
    {
        pozitie.y = 2.6f;
        pozitie.x = transform.position.x;
        pozitie.z = transform.position.z;
        StartCoroutine(waiter());
        
    }


    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(5);
        GameObject newObject = Instantiate(patrol, pozitie, transform.rotation);
        newObject.GetComponent<enemyPatrol>().player = Player;
        newObject.GetComponent<enemyPatrol>().leftEdge = Le.transform;
        newObject.GetComponent<enemyPatrol>().rightEdge = Re.transform;
        yield return new WaitForSeconds(0.1f);
      Destroy(me);

    }
}

