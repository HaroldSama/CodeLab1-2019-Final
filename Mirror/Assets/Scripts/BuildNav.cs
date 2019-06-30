using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildNav : MonoBehaviour
{
    NavMeshSurface surface;
    public GameObject player;
    public static BuildNav buildNav;
    
    private Rigidbody rb;
    private NavMeshAgent agent;

    private void Awake()
    {
        buildNav = this;
        surface = gameObject.GetComponent<NavMeshSurface>();
        agent = player.GetComponent<NavMeshAgent>();
        rb = player.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Build", 0.1f);
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
