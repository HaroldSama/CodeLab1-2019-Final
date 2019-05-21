using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipPlaneDrawer : MonoBehaviour
{
    public GameObject[] vertices;
    public Plane[] planes = new Plane[5];

    private Camera mainCam;

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
        DrawPlane();
    }

    public void DrawPlane()
    {
        //left
        planes[0] = new Plane(mainCam.transform.position, vertices[0].transform.position, vertices[1].transform.position);
        
        //right
        planes[1] = new Plane(mainCam.transform.position, vertices[2].transform.position, vertices[3].transform.position);
        
        //up
        planes[2] = new Plane(mainCam.transform.position, vertices[3].transform.position, vertices[0].transform.position);
        
        //dowm
        planes[3] = new Plane(mainCam.transform.position, vertices[1].transform.position, vertices[2].transform.position);
        
        //face
        planes[4] = new Plane(vertices[0].transform.position, vertices[3].transform.position, vertices[2].transform.position);
    }
}
