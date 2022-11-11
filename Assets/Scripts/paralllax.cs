using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralllax : MonoBehaviour
{
    public Camera cam;
    public Transform subject;

    Vector2 startpos;

    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startpos;
    float distanceFromSubject => transform.position.z - subject.position.z;
    float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(distanceFromSubject)/clippingPlane;
    public void Start()
    {
        startpos = transform.position;
        startZ= transform.position.z;
    }

   
    public void Update()
    {
        Vector2 newPos = startpos + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }
}
