﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class MirrorMover : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 MousePos;
    private Vector3 reference;
    //private bool aligning;

    public float allignTime;

    public float Xmin;
    public float Xmax;

    //public GameObject test;
    

    private void Awake()
    {
        mainCam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Draw a plane to map the position the mirror should go if dragged
        Plane plane = new Plane(transform.up, transform.position);
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float dist))
        {
            MousePos = ray.GetPoint(dist);
            MousePos.x = Mathf.Clamp(MousePos.x, Xmin, Xmax);
        }

        //test.transform.position = MousePos;
        //Vector3 dist = transform.position - mainCam.transform.position;
        Debug.DrawRay(transform.position, transform.forward * 100, Color.yellow);
        Debug.DrawLine(mainCam.transform.position, MousePos, Color.blue);
        /*MousePos = Input.mousePosition;
        MousePos.z = dist.magnitude;
        MousePos = mainCam.ScreenToWorldPoint(MousePos);*/
    }

    private void OnMouseDown()
    {
        reference = MousePos;
    }

    private void OnMouseDrag()
    {
        //print("Darg");
        
        if (name.Contains("X"))
        {
            float x = MousePos.x - reference.x;
            transform.parent.position += new Vector3(x,0,0);
            reference = MousePos;
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
    }
}