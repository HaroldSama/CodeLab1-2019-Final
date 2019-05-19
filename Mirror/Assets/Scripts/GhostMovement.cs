using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public GameObject origin;

    public GameObject mirror;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Plane mirrorPlane = new Plane(mirror.transform.forward, mirror.transform.position);
        Vector3 center = mirrorPlane.ClosestPointOnPlane(origin.transform.position);
        transform.position = center * 2 - origin.transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.Reflect(origin.transform.forward, mirrorPlane.normal));
    }
}
