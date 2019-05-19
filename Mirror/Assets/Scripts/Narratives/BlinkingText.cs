using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    private Text text;
    private Color oriColor;
    public AnimationCurve animCurve;
    public float period;
    public Color targetColor;

    void Awake()
    {
        text = GetComponent<Text>();
        oriColor = text.color;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Blink()
    {
        float timer = 0;

        while (timer < period)
        {
            text.color = Color.Lerp(oriColor, targetColor, animCurve.Evaluate(timer / period));

            timer += Time.deltaTime;

            yield return 0;
        }

        StartCoroutine(Blink());
    }
}
