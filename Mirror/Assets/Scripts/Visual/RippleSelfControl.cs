using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleSelfControl : MonoBehaviour
{

    public void InvokeRecycle()
    {
        Invoke("ReCycle", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReCycle()
    {
        RipplePool.instance.ripples.Add(gameObject);
    }
}
