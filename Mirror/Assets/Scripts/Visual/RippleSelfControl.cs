using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleSelfControl : MonoBehaviour
{

    public IEnumerator InvokeRecycle()
    {
        yield return new WaitForSeconds(1);
        ReCycle();
        //Invoke("ReCycle", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReCycle()
    {
        if (name.Contains("Ghost"))
        {
            RipplePool.instance.ripplesGhost.Add(gameObject);
        }
        else
        {
            RipplePool.instance.ripples.Add(gameObject);
        }
    }
}
