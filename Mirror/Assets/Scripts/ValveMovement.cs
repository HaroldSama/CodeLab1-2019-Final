using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Plane = UnityEngine.Plane;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class ValveMovement : MonoBehaviour
{
    [Tooltip("0:left\n1:right\n2:up\n3:down\n4:face\n-1:none")]
    public int planeFollow;
    //0:left 1:right 2:up 3:down 4:face -1:none
    
    public ClipPlaneDrawer mirrorClipPlane;
    
    public Vector3 track;
    public bool trackIsRotateable;
    public Transform trackRoot;
    public Transform trackTip;
    
    public Collider path;
    
    private Camera mainCam;
    private Vector3 oriScale;
    private NavMeshModifier navMod;

    private Vector3 oriPos;
    private Quaternion oriRota;

    public bool statical;
    public bool rotate = true;

    private void Awake()
    {
        mainCam = Camera.main;
        oriScale = transform.localScale;
        navMod = GetComponent<NavMeshModifier>();
        oriPos = transform.localPosition;
        oriRota = transform.localRotation;

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
        if (statical)
        {
            return;
        }
        
        //If the ghost is in front of the mirror, which means the original object is on the back of the mirror:
        //or the valve is not asked to follow any plane
        if ((planeFollow != 4 && mirrorClipPlane.planes[4].GetSide(transform.position)) || planeFollow == -1)
        {
            transform.localPosition = oriPos;
            transform.localRotation = oriRota;
            return;
        }

        if (trackIsRotateable)
        {
            track = trackTip.position - trackRoot.position;
        }

        
        Ray ray1 = new Ray(transform.position, track);
        Debug.DrawRay(ray1.origin, ray1.direction, Color.green);
        if (mirrorClipPlane.planes[planeFollow].Raycast(ray1, out float dist1))
        {
            transform.position = ray1.GetPoint(dist1);  
        }
        
        Ray ray2 = new Ray(transform.position, -track);
        Debug.DrawRay(ray2.origin, ray2.direction, Color.green);
        if (mirrorClipPlane.planes[planeFollow].Raycast(ray2, out float dist2))
        {
            transform.position = ray2.GetPoint(dist2);  
        }

        if (rotate)
        {
            transform.rotation = Quaternion.LookRotation(mirrorClipPlane.planes[planeFollow].normal);
        }
        

        //transform.localScale = new Vector3(oriScale.x / Mathf.Cos(transform.localEulerAngles.y * Mathf.Deg2Rad) * 0.9f, oriScale.y, oriScale.z);
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Path") && other != path)
        {
            /*if (gameObject.name == "Valve 0 Ghost 1")
            {
                print(other.name);
                //print(transform.parent.name);
            }*/
            
            //print(name + " Connect with " + other.name);
            //print(other.name);
            navMod.ignoreFromBuild = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Path") && other != path)
        {
            //print(name + " Disconnect with " + other.name);
            navMod.ignoreFromBuild = false;
        }
    }
}
