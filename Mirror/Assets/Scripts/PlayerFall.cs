using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Environments;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFall : MonoBehaviour
{
    public float deadLine;
    public bool loading;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!loading && transform.position.y < deadLine)
        {
            loading = true;
            StartCoroutine(SceneFader.Instance.FadeAndLoad(SceneManager.GetActiveScene().buildIndex, 1f)); 
        }
    }
}
