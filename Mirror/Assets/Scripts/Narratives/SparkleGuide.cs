using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SparkleGuide : MonoBehaviour
{
    public List<Transform> guides;
    public float travelTime;
    public int step;
    public bool moving;
    public float endingTime;
    
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
        if (other.CompareTag("Player") && !moving)
        {
            print("Entered");
            StartCoroutine(Travel(guides[step]));
            moving = true;

            if (step == 0)
            {
                NavMeshController.Freeze = true;
                StartCoroutine(NarrativeManager.instance.MoveCamera(NarrativeManager.instance.CameraGuide[NarrativeManager.instance.cameraStep]));
                StartCoroutine(NarrativeManager.instance.MovePath());
            }

            if (step == guides.Count - 1)
            {
                StartCoroutine(SceneFader.Instance.FadeAndLoad(
                    (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings, endingTime));
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

        moving = false;
        NavMeshController.Freeze = false;
        step++;
    }
}
