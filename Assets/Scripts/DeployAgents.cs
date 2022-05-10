using System.Collections;
using System.Collections.Generic;
using ComplexAgentsGame2D;
using UnityEngine;

public class DeployAgents : MonoBehaviour
{
    
    public Agent agent;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Random.insideUnitCircle * 50;
    }

    // Update is called once per frame
    void Update()
    {
    }
}