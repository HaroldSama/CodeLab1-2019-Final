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
        //Build navmesh at the start of the game
        Build();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unbuild() //Make character being able to fall when the path was move off her feet
    {
        rb.isKinematic = false;
        agent.enabled = false;
    }
    
    public void Build()
    {
        Invoke("Building", 0.1f);
    }

    void Building()
    {
        print("Build");
        surface.BuildNavMesh();
        
        //If player didn't fall off, put it back to the NavMesh
        if (player.transform.position.y > - 0.1)
        {
            rb.isKinematic = true;
            agent.enabled = true;
        }        
    }
}
