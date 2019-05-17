using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirorCam : MonoBehaviour
{
    public GameObject mirror;
    private Camera cam;
    public GameObject mainCam;
    public float mirrorWide;
    public float mirrorHeight;
    public int adjust;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 reflect = - Vector3.Reflect(mirror.transform.position - mainCam.transform.position, mirror.transform.forward);
        
        Debug.DrawRay(mirror.transform.position, mirror.transform.forward, Color.red);
        Debug.DrawRay(mainCam.transform.position, mirror.transform.position - mainCam.transform.position, Color.red);
        Debug.DrawRay(mirror.transform.position, reflect, Color.red);

        /*float offsetZ = mainCam.transform.position.z - mirror.transform.position.z;
        float offsetX = mainCam.transform.position.x - mirror.transform.position.x;
        float offsetY = mainCam.transform.position.y - mirror.transform.position.y;*/

        transform.position = mirror.transform.position + reflect;

        Vector3 pos = transform.localPosition;
        //transform.LookAt(mirror.transform);
        //print(reflect.magnitude);
        //cam.lensShift = new Vector2(cam.lensShift.x, 0.15f / offsetZ);
        cam.nearClipPlane = Mathf.Abs(pos.z);
        
        cam.fieldOfView = Mathf.Atan(mirrorHeight / 2 / Mathf.Abs(pos.z)) * Mathf.Rad2Deg * 2;
        
        cam.lensShift = new Vector2(- adjust * pos.x / mirrorWide, - pos.y / mirrorHeight);



        //print(Mathf.Atan(1f / 1.85f) * Mathf.Rad2Deg + Mathf.Atan(1f / 1.85f) * Mathf.Rad2Deg);


    }
}
