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
        }
        
        
    }

    IEnumerator Travel(Transform guide)
    {
        float timer = 0;

        while (timer < travelTime)
        {
            transform.position = Vector3.Lerp(transform.position, guide.position, timer / travelTime);

            timer += Time.deltaTime;

            yield return 0;
        }

        step++;
    }
}
