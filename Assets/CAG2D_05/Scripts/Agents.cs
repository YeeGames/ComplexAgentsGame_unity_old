using CAG2D_05.Scripts.Rules;
using CAG2D_05.Scripts.Settings;
using CAG2D_05.Scripts.YeeTypes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CAG2D_05.Scripts
{
    public class Agents : MonoBehaviour
    {
        public GameSettings gameSettings;

        public Agent agent;
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
                    Agent a = Instantiate(agent);

                    Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                    a.aset.position = pos;
                    a.aset.velocity = Random.insideUnitCircle;
                    a.aset.yeeType2E = yeeTypes[t];
                    a.aset.color = typesColors[t];
                    a.aset.agentName = a.aset.agentBaseName + yeeTypes[t].ToString() + i.ToString();

                    a.Initialize(a.aset, a.rset);
                }
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