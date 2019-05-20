﻿using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Plane = UnityEngine.Plane;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class ValveMovement : MonoBehaviour
{
    public int planeFollow;
    public GameObject[] vertices;
    private Camera mainCam;
    private Vector3 oriScale;
    private NavMeshModifier navMod;

    public Plane[] planes = new Plane[5];

    private void Awake()
    {
        mainCam = Camera.main;
        oriScale = transform.localScale;
        navMod = GetComponent<NavMeshModifier>();

        /*foreach (var vertex in vertices)
        {
            Debug.DrawLine(mainCam.transform.position, vertex.transform.position, Color.magenta, float.MaxValue);
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        planes[0] = new Plane(mainCam.transform.position, vertices[0].transform.position, vertices[1].transform.position);
        planes[1] = new Plane(mainCam.transform.position, vertices[2].transform.position, vertices[3].transform.position);
        planes[2] = new Plane(mainCam.transform.position, vertices[3].transform.position, vertices[1].transform.position);
        planes[3] = new Plane(mainCam.transform.position, vertices[1].transform.position, vertices[2].transform.position);
        planes[4] = new Plane(vertices[0].transform.position, vertices[3].transform.position, vertices[2].transform.position);
        
        Ray ray1 = new Ray(transform.position, Vector3.back);
        Debug.DrawRay(ray1.origin, ray1.direction, Color.green);
        if (planes[planeFollow].Raycast(ray1, out float dist1))
        {
            transform.position = ray1.GetPoint(dist1);  
        }
        
        Ray ray2 = new Ray(transform.position, Vector3.forward);
        Debug.DrawRay(ray2.origin, ray2.direction, Color.green);
        if (planes[planeFollow].Raycast(ray2, out float dist2))
        {
            transform.position = ray2.GetPoint(dist2);  
        }

        transform.rotation = Quaternion.LookRotation(planes[planeFollow].normal);

        transform.localScale = new Vector3(oriScale.x / Mathf.Cos(transform.localEulerAngles.y * Mathf.Deg2Rad) * 0.9f, oriScale.y, oriScale.z);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Path") && other.name != transform.parent.name)
        {
            //print(other.name);
            //print(transform.parent.name);
            print("Connected");
            navMod.ignoreFromBuild = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Path") && other.name != transform.parent.name)
        {
            print("Disconnected");
            navMod.ignoreFromBuild = false;
        }
    }
}
