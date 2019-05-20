using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveSafeZone : MonoBehaviour
{
    public Transform valve;
    public Vector3 orientation;
    public float lMin;

    public float lMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(
            Mathf.Clamp(1 - orientation.x + Mathf.Abs(transform.position.x - valve.transform.position.x), lMin, lMax),
            Mathf.Clamp(1 - orientation.y + Mathf.Abs(transform.position.y - valve.transform.position.y), lMin, lMax), 
            Mathf.Clamp(1 - orientation.z + Mathf.Abs(transform.position.z - valve.transform.position.z), lMin, lMax));
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            print("Kill");
        }
    }*/
}
