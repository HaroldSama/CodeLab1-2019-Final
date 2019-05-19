﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    //public Vector3 destination;
    //private Vector3 oldDest;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.SetDestination(destination);

        //oldDest = destination;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (destination != oldDest)
        {
            agent.SetDestination(destination);
            oldDest = destination;
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit = new RaycastHit();
            LayerMask mask = LayerMask.GetMask("Path");

            if (Physics.Raycast(ray.origin, ray.direction, out hit, 2000.0f, mask))
            {
                //destination = hit.point;
                //print("go");
                agent.SetDestination(hit.point);
            }
        }
    }
}
