using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveSafeZone : MonoBehaviour
{
    public Transform valve;

    public float lMin;

    public float lMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Clamp(transform.position.z - valve.transform.position.z, lMin, lMax));
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            print("Kill");
        }
    }*/
}
