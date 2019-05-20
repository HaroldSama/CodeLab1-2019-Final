using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameGlow : MonoBehaviour
{
    public Material original;
    public Material glowing;
    public List<MeshRenderer> accessories;
    public List<Material> accessoryMats;
    private MeshRenderer rd;

    private void Awake()
    {
        rd = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnMouseOver()
    {
        rd.material = glowing;
        for (int i = 0; i < accessories.Count; i++)
        {
            accessories[i].material = glowing;
        }
    }

    private void OnMouseExit()
    {
        rd.material = original;
        for (int i = 0; i < accessories.Count; i++)
        {
            accessories[i].material = accessoryMats[i];
        }
    }
}
