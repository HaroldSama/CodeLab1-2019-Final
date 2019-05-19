using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildNav : MonoBehaviour
{
    NavMeshSurface surface;

    public static BuildNav buildNav;

    private void Awake()
    {
        buildNav = this;
        surface = gameObject.GetComponent<NavMeshSurface>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Build()
    {
        print("Build");
        surface.BuildNavMesh();
    }
}
