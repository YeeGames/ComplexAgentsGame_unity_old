using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                Agent dotTai = Instantiate(agentPrefab);
                dotTai.SetPosition(pos);
                Debug.Log("Position of particle " + i.ToString() + " is " + pos.ToString());
                // dotTai.velocity = (Vector2) Random.insideUnitCircle;
                dotTai.set.type = AgentSettings.EType.Tai;
                dotTai.SetColor(Color.red);
            }

            // agentPrefab.set.type = AgentSettings.EType.Yin;
            // agentPrefab.SetColor(Color.blue);
        // TODO 加上Yin和Yang   
        //     foreach (var type in {
        //         AgentSettings.EType.Yang,
        //     })
        //     {
        //     }
        //
        //
        //     for (var i = 0; i < numAgent; i++)
        //     {
        //         Vector2 pos = (Vector2) (this.transform.position) + (Vector2) (this.transform.forward * radiusSize) +
        //                       Random.insideUnitCircle * radiusSize;
        //         Agent dotYin = Instantiate(agentPrefab);
        //         dotYin.SetPosition(pos);
        //         Debug.Log("Position of " +
        //                   AgentSettings.EType.Yin.ToString() + " agent " + i.ToString() + " is " + pos.ToString());
        //         Vector2 vel = Random.insideUnitCircle;
        //         dotYin.transform.forward = vel;
        //         Debug.Log("Velocity of agent " + i.ToString() + " is " + vel.ToString());
        //         dotYin.set.type = AgentSettings.EType.Yin;
        //         dotYin.SetColor(Color.blue);
        //     }
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