using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveManager : MonoBehaviour
{
    public ValveMovement valve;
    public ClipPlaneDrawer mirrorClipPlane;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If this object is to the left of the left plane, make the valve follows the left plane
        if (!mirrorClipPlane.planes[0].GetSide(transform.position))
        {
            valve.planeFollow = 0;
        }
        //If this object is to the right of the right plane, make the valve follows the right plane
        else if(!mirrorClipPlane.planes[1].GetSide(transform.position))
        {
            valve.planeFollow = 1;
        }
        //If this object is between left plane and right plane, make the valve follows nothing
        else
        {
            valve.planeFollow = -1;
        }
            
    }
}
