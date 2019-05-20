using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public float fadeTime;
    public static SceneFader Instance;
    private Image image;

    private void Awake()
    {
        Instance = this;
        image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Initial()
    {
        float timer = 0;

        while (timer < fadeTime)
        {
            image.color = Color.Lerp(Color.black, Color.clear, timer / fadeTime);

            timer += Time.deltaTime;

            yield return 0;
        }
    }
    
    public IEnumerator FadeAndLoad(int sceneIndex)
    {
        float timer = 0;

        while (timer < fadeTime)
        {
            image.color = Color.Lerp(Color.clear, Color.black, timer / fadeTime);

            timer += Time.deltaTime;

            yield return 0;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
