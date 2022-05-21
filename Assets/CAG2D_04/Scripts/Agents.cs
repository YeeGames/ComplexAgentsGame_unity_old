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
        public YeeType2Y[] yeeTypes = {YeeType2Y.Yang, YeeType2Y.Yin};


        private void Awake()
        {
            foreach (var yeeType in yeeTypes)
            {
                for (var i = 0; i < gameSettings.numAgent; i++)
                {
                    Agent a = Instantiate(agentPrefab);
                    agentSettings.agentName = agentSettings.agentBaseName + i;
                    Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                    agentSettings.position = pos;
                    agentSettings.velocity = Random.insideUnitCircle;
                    agentSettings.yeeType2Y = yeeType;
                    a.SetAgent(agentSettings);
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            System.Threading.Thread.Sleep(1000 * gameSettings.pauseTime);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
        }
    }
}