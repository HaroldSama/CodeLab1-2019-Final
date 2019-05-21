using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveSafeZone : MonoBehaviour
{
    public Transform valve;
    public Vector3 orientation;
    public float lMin;
    public float lMax;

    public bool mobile;
    public Transform rootValve;

    private Vector3 oriPos;

    private void Awake()
    {
        oriPos = transform.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newMax = lMax;
        
        if (mobile)
        {
            Vector3 newPos = new Vector3();
            newPos.x = Mathf.Clamp(rootValve.localPosition.x, oriPos.x + lMin, oriPos.x + lMax);
            newPos.y = Mathf.Clamp(rootValve.localPosition.y, oriPos.y + lMin, oriPos.y + lMax);
            newPos.z = Mathf.Clamp(rootValve.localPosition.z, oriPos.z + lMin, oriPos.z + lMax);

            transform.localPosition = newPos;

            newMax = lMax - orientation.x * (newPos.x - oriPos.x) - orientation.y * (newPos.y - oriPos.y) - orientation.z * (newPos.z - oriPos.z);
            
            transform.localScale = new Vector3(
                Mathf.Clamp(1 - orientation.x + valve.transform.localPosition.x - transform.localPosition.x, lMin, newMax),
                Mathf.Clamp(1 - orientation.y + valve.transform.localPosition.y - transform.localPosition.y, lMin, newMax), 
                Mathf.Clamp(1 - orientation.z + valve.transform.localPosition.z - transform.localPosition.z, lMin, newMax));
        }
        else
        {
            transform.localScale = new Vector3(
                Mathf.Clamp(1 - orientation.x + Mathf.Abs(transform.localPosition.x - valve.transform.localPosition.x), lMin, newMax),
                Mathf.Clamp(1 - orientation.y + Mathf.Abs(transform.localPosition.y - valve.transform.localPosition.y), lMin, newMax), 
                Mathf.Clamp(1 - orientation.z + Mathf.Abs(transform.localPosition.z - valve.transform.localPosition.z), lMin, newMax));        
        }
        

    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            print("Kill");
        }
    }*/
}
