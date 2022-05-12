using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// using ComplexAgentsGame2D;
namespace ComplexAgentsGame2D
{
    public class Agents : MonoBehaviour
    {
        public Agent agentPrefab;
        public GameSettings gameSettings;
        public Color colour = Color.green;
        public AgentSettings agentSettings;
        public float radiusSize = 30f;

        private void Awake()
        {
            // this.colour = gameSettings.colour;
            // Deploy agents
            for (var i = 0; i < gameSettings.numOfAgent; i++)
            {
                Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                Agent agent = Instantiate(agentPrefab);
                agent.SetPosition(pos);
                // Debug.Log("Position of agent " + i.ToString() + " is " + pos.ToString());
                // agent.transform.forward = (Vector2) Random.insideUnitCircle;
                agent.SetColor(this.colour);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void FixedUpdate()
        {
        }
    }
}