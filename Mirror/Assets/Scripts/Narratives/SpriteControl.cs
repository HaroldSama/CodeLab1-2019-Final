using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteControl : MonoBehaviour
{
    private SpriteRenderer sprite;
    //private Color oriColor;
    public AnimationCurve animCurve;
    public float period;
    public Color targetColor;
    public float disappearTime;
    public float appearTime;

    public bool shouldDisappear;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        //oriColor = text.color;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (sprite.color.a != 0)
        {
            StartCoroutine(Blink());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Blink()
    {
        Color currentColor = sprite.color;
        float timer = 0;

        while (!shouldDisappear)
        {
            sprite.color = Color.Lerp(currentColor, targetColor, animCurve.Evaluate(timer / period));

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

        Color currentColor = sprite.color;
        float timer = 0;

        while (timer < disappearTime)
        {
            sprite.color = Color.Lerp(currentColor, Color.clear, timer / disappearTime);

            timer += Time.deltaTime;
            yield return 0;
        }
    }
    
    public IEnumerator Appear()
    {
        //shouldDisappear = true;
        //StopCoroutine(Blink());
        //print("Disappear!");

        Color currentColor = sprite.color;
        float timer = 0;

        while (timer < appearTime)
        {
            sprite.color = Color.Lerp(currentColor, Color.white, timer / appearTime);

            timer += Time.deltaTime;
            yield return 0;
        }

        StartCoroutine(Blink());
    }
}
