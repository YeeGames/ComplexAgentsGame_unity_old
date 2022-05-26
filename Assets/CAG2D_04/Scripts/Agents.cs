using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CAG2D_04.Scripts
{
    public class Agents : MonoBehaviour
    {
        public GameSettings gameSettings;

        public AgentSettings agentSettings;

        // public ScriptableObject ruleSettings =
        //     AssetDatabase.LoadAssetAtPath<RuleSettings>(@"Assets/CAG2D_04/Settings/Rule Settings.asset"); // 代码加载脚本对象失败

        public RuleSettings ruleSettings;
        public Agent agent;
        public float radiusSize = 30f;
        public YeeType2E[] yeeTypes = {YeeType2E.Yang, YeeType2E.Yin};
        public Color[] typesColors = {Color.red, Color.blue};
        private RuleYeeType2E ruleYeeType2E;

        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {
            for (var t = 0; t < yeeTypes.Length; t++)
            {
                for (var i = 0; i < gameSettings.numAgent; i++)
                {
                    agentSettings.agentName = agentSettings.agentBaseName + yeeTypes[t].ToString() + i.ToString();
                    Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                    agentSettings.position = pos;
                    agentSettings.velocity = Random.insideUnitCircle;
                    agentSettings.yeeType2E = yeeTypes[t];
                    agentSettings.color = typesColors[t];
                    Agent a = Instantiate(agent);
                    a.Initialize(agentSettings, ruleSettings);
                }
            }
        }


        // Update is called once per frame
        void FixedUpdate()
        {
        }
    }
}