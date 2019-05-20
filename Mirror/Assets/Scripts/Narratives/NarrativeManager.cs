using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public List<TextControl> TextControls;
    public List<Transform> CameraGuide;
    public List<Transform> paths;
    public List<Transform> pathTargets;
    
    public float cameraMovingTime;
    public static NarrativeManager instance;
    public int cameraStep;
    
    public int pathStep;
    public float pathMovingTime;
    private Camera mainCam;

    private void Awake()
    {
        instance = this;
        mainCam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MoveCamera(Transform guide)
    {
        //print("MoveCamera");
        float timer = 0;
        Vector3 oriPos = mainCam.transform.position;
        Quaternion oriRota = mainCam.transform.rotation;

        while (timer < cameraMovingTime)
        {
            mainCam.transform.position =
                Vector3.Lerp(oriPos, guide.position, timer / cameraMovingTime);
            
            mainCam.transform.rotation = Quaternion.Slerp(oriRota, guide.rotation, timer / cameraMovingTime);

            timer += Time.deltaTime;

            yield return 0;
        }

        cameraStep++;
    }

    public IEnumerator MovePath()
    {
        float timer = 0;
        Vector3 oriPos = paths[pathStep].position;

        while (timer < pathMovingTime)
        {
            paths[pathStep].position = Vector3.Lerp(oriPos, pathTargets[pathStep].position, timer / pathMovingTime);

            timer += Time.deltaTime;

            yield return 0;
        }

        pathStep++;
    }
}
