using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SparkleGuide : MonoBehaviour
{
    public List<Transform> guides;
    public float travelTime;
    public int step;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Entered");
            StartCoroutine(Travel(guides[step]));
            NavMeshController.Freeze = true;

            if (step == 0)
            {
                StartCoroutine(NarrativeManager.instance.MoveCamera(NarrativeManager.instance.CameraGuide[NarrativeManager.instance.cameraStep]));
                StartCoroutine(NarrativeManager.instance.MovePath());
            }
        }
        
        
    }

    IEnumerator Travel(Transform guide)
    {
        float timer = 0;
        Vector3 oriPos = transform.position;

        while (timer < travelTime)
        {
            transform.position = Vector3.Lerp(oriPos, guide.position, timer / travelTime);

            timer += Time.deltaTime;

            yield return 0;
        }

        NavMeshController.Freeze = false;
        step++;
    }
}
