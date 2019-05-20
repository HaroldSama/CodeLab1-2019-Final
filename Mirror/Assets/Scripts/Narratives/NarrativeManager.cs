using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public List<TextControl> TextControls;

    public static NarrativeManager instance;

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
}
