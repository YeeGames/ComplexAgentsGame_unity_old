using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// using ComplexAgentsGame2D;
namespace ComplexAgentsGame2D
{
    public class AgentsManager : MonoBehaviour
    {
        public Agent agent;
        public Color color;
        public GameSettings gameSettings;

        private void Awake()
        {
            // Deploy agents
            for (int i = 0; i < gameSettings.numOfAgent; i++)
            {
                Vector2 pos = (Vector2) transform.position + Random.insideUnitCircle * agent.size;
                Agent a = Instantiate(this.agent);
                a.transform.position = pos;
                a.transform.forward = Random.insideUnitCircle;
                a.setColor(color);
            }
        }

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
}