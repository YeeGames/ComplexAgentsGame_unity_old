using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CAG2D_04.Scripts
{
    public class Agents : MonoBehaviour
    {
        public GameSettings gameSettings;
        public AgentSettings agentSettings;
        public Agent agentPrefab;
        public float radiusSize = 30f;
        public YeeType2E[] yeeTypes = {YeeType2E.Yang, YeeType2E.Yin};
        public Color[] typesColors = {Color.red, Color.blue};
        private RuleYeeType2E ruleYeeType2E;

        private void Awake()
        {
            for (var t = 0; t < yeeTypes.Length; t++)
            {
                for (var i = 0; i < gameSettings.numAgent; i++)
                {
                    Agent a = Instantiate(agentPrefab);
                    agentSettings.agentName = agentSettings.agentBaseName + a.set.yeeType2E.ToString() + i.ToString();
                    Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                    agentSettings.position = pos;
                    agentSettings.velocity = Random.insideUnitCircle;
                    agentSettings.yeeType2E = yeeTypes[t];
                    agentSettings.color = typesColors[t];
                    a.SetAgent(agentSettings);
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            // System.Threading.Thread.Sleep(1000 * gameSettings.pauseTime);
        }


        // Update is called once per frame
        void FixedUpdate()
        {
        }
    }
}