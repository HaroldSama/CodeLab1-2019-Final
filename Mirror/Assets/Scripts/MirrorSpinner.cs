using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSpinner : MonoBehaviour
{
    public float rotateTime = 1;
    public float minAngle;
    public float maxAngle;
    public Vector3 angle;
    private Vector3 oriAngle;
    private bool rotating;

    private void Awake()
    {
        oriAngle = transform.parent.localEulerAngles;
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
        Vector3 angleRotated = transform.parent.localEulerAngles - oriAngle;
        float angleSum = angleRotated.x + angleRotated.y + angleRotated.z;
        //print(angleSum);
        
        if (!rotating && angleSum > minAngle && angleSum < maxAngle)
        {
            print("Rotate");
            rotating = true;
            BuildNav.buildNav.Unbuild();
            StartCoroutine(RotateMirror());
        }
        
    }

    IEnumerator RotateMirror()
    {
        float timer = 0;

        Vector3 currentAngle = transform.parent.localEulerAngles;
        Vector3 targetAngle = transform.parent.localEulerAngles + angle;
            
        while (timer * Time.deltaTime < rotateTime)
        {
            transform.parent.localEulerAngles =
                Vector3.Lerp(currentAngle, targetAngle, timer * Time.deltaTime / rotateTime);

            timer++;

            yield return 0;
        }

        transform.parent.localEulerAngles = targetAngle;
        rotating = false;
        BuildNav.buildNav.Build();
    }
}
