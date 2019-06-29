using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    public GameObject origin;

    public GameObject mirror;
    public bool inverser;
    public GameObject path;

    /*private void Awake()
    {
        path = GetComponent<NavMeshModifier>();
    }*/

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

        if (inverser)
        {
            if ((transform.position.x < origin.transform.position.x && path.activeSelf) || (transform.position.x > origin.transform.position.x && !path.activeSelf))
            {
                path.SetActive(!path.activeSelf);
            }
        }
    }
}
