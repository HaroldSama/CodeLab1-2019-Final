using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpecialValve : MonoBehaviour
{
    public NavMeshModifier linkedValve;

    private NavMeshModifier navMod;

    private void Awake()
    {
        navMod = GetComponent<NavMeshModifier>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        navMod.ignoreFromBuild = linkedValve.ignoreFromBuild;
    }
}
