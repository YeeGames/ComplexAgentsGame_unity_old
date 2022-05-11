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
        public Color color;
        public GameSettings gameSettings;
        public AgentSettings agentSettings;

        private void Awake()
        {
            // Deploy agents
            for (int i = 0; i < gameSettings.numOfAgent; i++)
            {
                Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * 10;
                Agent agent = Instantiate(agentPrefab);
                agent.position = (Vector2) pos;
                agent.forward = (Vector2) Random.insideUnitCircle;
                agent.SetColor(gameSettings.color);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            transform.position = (Vector2) (Random.insideUnitCircle * 10f);
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}