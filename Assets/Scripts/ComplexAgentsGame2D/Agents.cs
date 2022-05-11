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
        public Color color;
        public AgentSettings agentSettings;

        private void Awake()
        {
            this.color = gameSettings.color;
            // Deploy agents
            for (int i = 0; i < gameSettings.numOfAgent; i++)
            {
                Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * 10;
                Debug.Log("Position of agent " + i.ToString() + " is " + pos.ToString());
                // Agent agent = Instantiate(Resources.Load<Agent>("Assets/Prefabs/Agent.prefab"));
                Agent agent = Instantiate(agentPrefab);
                agent.position = (Vector2) pos;
                agent.forward = (Vector2) Random.insideUnitCircle;
                agent.SetColor(gameSettings.color);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            // transform.position = (Vector2) (Random.insideUnitCircle * 10f);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
        }
    }
}