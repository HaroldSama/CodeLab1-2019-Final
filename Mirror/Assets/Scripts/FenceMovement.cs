using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceMovement : MonoBehaviour
{
    public GameObject mirror;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scale = Mathf.Abs(mirror.transform.position.z - transform.position.z) - 2;
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }
}
