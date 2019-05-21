using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public static bool Freeze;
    //public Vector3 destination;
    //private Vector3 oldDest;

    private NavMeshAgent agent;

    private Animator anim;
    private Animator animGhost;
    private Rigidbody rb;

    public bool firstClick;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        animGhost = GameObject.Find("Player Ghost").GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //agent.SetDestination(destination);

        //oldDest = destination;
    }

    // Update is called once per frame
    void Update()
    {        

        if (agent.velocity.magnitude > 0)
        {
            anim.SetBool("IsWalking", true);
            animGhost.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
            animGhost.SetBool("IsWalking", false);
        }        
        
        if (Freeze)
        {
            return;
        }
        
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
                //agent.updatePosition = false;
                //agent.updateRotation = false;
                agent.SetDestination(hit.point);
                RipplePool.instance.GetRipple(hit.point);
                
                if (!firstClick)
                {
                    firstClick = true;
                    StartCoroutine(NarrativeManager.instance.TextControls[0].Disappear());
                }
                
            }
        }

    }
}
