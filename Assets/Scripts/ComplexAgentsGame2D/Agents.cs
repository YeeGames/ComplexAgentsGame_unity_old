using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

// using ComplexAgentsGame2D;
namespace ComplexAgentsGame2D
{
    public class Agents : MonoBehaviour
    {
        public Agent agentPrefab;
        public GameSettings gameSettings;
        public Color colour = Color.white;
        public AgentSettings agentSettings;
        public float radiusSize = 10f;
        public int numAgent = 10;

        private void Awake()
        {
            // this.colour = gameSettings.colour;
            // Deploy agents

            // agentPrefab.set.type = AgentSettings.EType.Yang;
            // agentPrefab.SetColor(Color.red);
            for (var i = 0; i < numAgent; i++)
            {
                Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                Agent particleYang = Instantiate(agentPrefab);
                particleYang.SetPosition(pos);
                Debug.Log("Position of agent " + i.ToString() + " is " + pos.ToString());
                particleYang.velocity = (Vector2) Random.insideUnitCircle;
                particleYang.set.type = AgentSettings.EType.Yang;
                particleYang.SetColor(Color.red);
            }

            // agentPrefab.set.type = AgentSettings.EType.Yin;
            // agentPrefab.SetColor(Color.blue);
            for (var i = 0; i < numAgent; i++)
            {
                Vector2 pos = (Vector2) (this.transform.position) + (Vector2) (this.transform.forward * radiusSize) +
                              Random.insideUnitCircle * radiusSize;
                Agent particleYin = Instantiate(agentPrefab);
                particleYin.SetPosition(pos);
                Debug.Log("Position of agent " + i.ToString() + " is " + pos.ToString());
                particleYin.transform.forward = (Vector2) Random.insideUnitCircle;
                particleYin.set.type = AgentSettings.EType.Yin;
                particleYin.SetColor(Color.blue);
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