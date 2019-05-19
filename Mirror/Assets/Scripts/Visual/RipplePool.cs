using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipplePool : MonoBehaviour
{
    public List<GameObject> ripples = new List<GameObject>();
    public GameObject ripplePrefab;

    public static RipplePool instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public GameObject GetRipple(Vector3 pos)
    {
        GameObject result = null;
        
        if (ripples.Count > 0) //Do we have any boxes to recycle?
        {
            //get a box out of the list and recycle it
            result = ripples[0];
            result.transform.position = pos;
            ripples.Remove(result);
            RestartRipple(result);
            //result.SetActive(true);
        }
        else  //No?
        {
            //make a new box
            result = Instantiate(ripplePrefab, pos, Quaternion.identity);
            result.transform.localEulerAngles = new Vector3(-90, 0, 0);//init prefab from resources
            RestartRipple(result);
        }

        return result;
    }
    
    void RestartRipple(GameObject ripple)
    {
        ripple.transform.Find("Particle System").GetComponent<ParticleSystem>().Play();
        ripple.GetComponent<RippleSelfControl>().InvokeRecycle();
    }
}
