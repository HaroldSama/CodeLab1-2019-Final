using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    private Text text;
    private Color oriColor;
    public AnimationCurve animCurve;
    public float period;
    public Color targetColor;
    public float disappearTime;

    private bool shouldDisappear;

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

        while (!shouldDisappear)
        {
            text.color = Color.Lerp(oriColor, targetColor, animCurve.Evaluate(timer / period));

            timer = (timer + Time.deltaTime) % period;

            yield return 0;
        }

        //StartCoroutine(Blink());
    }

    public IEnumerator Disappear()
    {
        shouldDisappear = true;
        //StopCoroutine(Blink());
        //print("Disappear!");

        Color currentColor = text.color;
        float timer = 0;

        while (timer < disappearTime)
        {
            text.color = Color.Lerp(currentColor, Color.clear, timer / disappearTime);

            timer += Time.deltaTime;
            yield return 0;
        }
    }
}
