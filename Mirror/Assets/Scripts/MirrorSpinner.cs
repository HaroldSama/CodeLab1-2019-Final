using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSpinner : MonoBehaviour
{
    public float rotateTime = 1;
    public Vector3 maxAngle;
    public Vector3 angle;
    private Vector3 oriAngle;
    private bool rotating;

    private void Awake()
    {
        oriAngle = transform.parent.transform.localEulerAngles;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        print("Rotate");
        if (!rotating)
        {
            rotating = true;
            StartCoroutine(RotateMirror());
        }
        
    }

    IEnumerator RotateMirror()
    {
        float timer = 0;

        Vector3 currentAngle = transform.parent.transform.localEulerAngles;
        Vector3 targetAngle = transform.parent.transform.localEulerAngles + angle;
            
        while (timer * Time.deltaTime < rotateTime)
        {
            transform.parent.transform.localEulerAngles =
                Vector3.Lerp(currentAngle, targetAngle, timer * Time.deltaTime / rotateTime);

            timer++;

            yield return 0;
        }

        transform.parent.transform.localEulerAngles = targetAngle;
        rotating = false;
    }
}
