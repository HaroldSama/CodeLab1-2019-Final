using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.AI;

public class MirrorMover : MonoBehaviour
{
    public GameObject player;
    
    private Camera mainCam;
    private Vector3 MousePos;

    private Plane normPlane;
    private Vector3 planePos;
    
    private Vector3 reference;
    private Rigidbody rb;
    private NavMeshAgent agent;

    public bool firstMove;
    //private bool aligning;

    public float allignTime;

    public float Xmin;
    public float Xmax;

    //public GameObject test;
    

    private void Awake()
    {
        mainCam = Camera.main;
        agent = player.GetComponent<NavMeshAgent>();
        rb = player.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Detect what is the mouse position on the plane of the mirror face
        Plane plane = new Plane(- transform.right, transform.position);
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        
        if (plane.Raycast(ray, out float dist))
        {
            MousePos = ray.GetPoint(dist);
            //MousePos.x = Mathf.Clamp(MousePos.x, Xmin, Xmax);
        }

        //test.transform.position = MousePos;
        //Vector3 dist = transform.position - mainCam.transform.position;
        
        
        /*MousePos = Input.mousePosition;
        MousePos.z = dist.magnitude;
        MousePos = mainCam.ScreenToWorldPoint(MousePos);*/ 
    }

    private void OnMouseDown()
    {
        //Draw a plane to map the position the mirror should go if dragged
        normPlane = new Plane(transform.up, MousePos);
        Debug.DrawRay(MousePos, transform.up, Color.yellow, float.MaxValue);
        
        //Debug.DrawRay(MousePos, transform.up, Color.cyan);
        reference = MousePos;
        //agent.velocity = Vector3.zero;
        //rb.velocity = Vector3.zero;
        
        //Make character being able to fall when the path was move off her feet
        rb.isKinematic = false;
        agent.enabled = false;

        if (!firstMove)
        {
            firstMove = true;
            StartCoroutine(NarrativeManager.instance.TextControls[1].Disappear());
            StartCoroutine(NarrativeManager.instance.SpriteControls[0].Disappear());
        }
    }

    private void OnMouseDrag()
    {
        //print("Darg");
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        
        if (normPlane.Raycast(ray, out float dist))
        {
            planePos = ray.GetPoint(dist);
            //print(planePos.x);
            planePos.x = Mathf.Clamp(planePos.x, Xmin, Xmax);
            //print("Clamp " + planePos.x);
        }
        
        Debug.DrawLine(mainCam.transform.position, planePos, Color.blue);
        
        if (name.Contains("X"))
        {
            float x = planePos.x - reference.x;
            transform.parent.position += new Vector3(x,0,0);
            reference = planePos;
        }       
    }

    private void OnMouseUp()
    {
        StartCoroutine(Align());
    }

    
    //Allign the mirror on grid
    IEnumerator Align()
    {
        float timer = 0;

        while (timer * Time.deltaTime < allignTime)
        {
            Vector3 start = transform.parent.position;
            Vector3 end = new Vector3(Mathf.Round(start.x), Mathf.Round(start.y), Mathf.Round(start.z));

            transform.parent.position = Vector3.Lerp(start, end, timer * Time.deltaTime / allignTime);

            timer++;
            
            yield return 0;
        }
        
        BuildNav.buildNav.Build();
        
        //If player didn't fall off, put it back to the NavMesh
        if (player.transform.position.y > - 1)
        {
            rb.isKinematic = true;
            agent.enabled = true;
        }
        
    }
}
