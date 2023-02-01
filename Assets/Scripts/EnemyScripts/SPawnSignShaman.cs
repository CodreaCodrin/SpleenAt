using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPawnSignShaman : MonoBehaviour
{
    public GameObject patrol;
    public GameObject me;
    private Vector3 pozitie;
    public GameObject Player;
    public GameObject Re;
    public GameObject Le;

    void Start()
    {
        pozitie.y = 2.53f;
        pozitie.x = transform.position.x;
        pozitie.z = transform.position.z;
        StartCoroutine(waiter());
    }


    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(5f);
        GameObject newObject = Instantiate(patrol, pozitie, transform.rotation);
        newObject.GetComponent<enemyPatrolShaman>().player = Player;
        newObject.GetComponent<enemyPatrolShaman>().leftEdge = Le.transform;
        newObject.GetComponent<enemyPatrolShaman>().rightEdge = Re.transform;
        yield return new WaitForSeconds(0.1f);
        Destroy(me);

    }
}
