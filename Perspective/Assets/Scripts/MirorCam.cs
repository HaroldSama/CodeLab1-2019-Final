using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirorCam : MonoBehaviour
{
    public GameObject mirror;
    private Camera cam;
    public GameObject mainCam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 reflect = Vector3.Reflect(mainCam.transform.position - mirror.transform.position, mirror.transform.forward);

        float offsetZ = mainCam.transform.position.z - mirror.transform.position.z;

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -offsetZ);
        //transform.LookAt(mirror.transform);
        //print(reflect.magnitude);
        //cam.lensShift = new Vector2(cam.lensShift.x, 0.15f / offsetZ);
        cam.fieldOfView = Mathf.Atan(1f / offsetZ) * Mathf.Rad2Deg + Mathf.Atan(1f / offsetZ) * Mathf.Rad2Deg;
        
        //print(Mathf.Atan(1f / 1.85f) * Mathf.Rad2Deg + Mathf.Atan(1f / 1.85f) * Mathf.Rad2Deg);
        

    }
}
