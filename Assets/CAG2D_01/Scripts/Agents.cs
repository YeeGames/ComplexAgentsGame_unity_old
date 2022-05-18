using UnityEngine;
using Random = UnityEngine.Random;
using CAG2D_00;

namespace CAG2D_01.Scripts
{
    public class Agents : MonoBehaviour
    {
        public GameSettings gameSettings;
        public AgentSettings agentSettings;
        public float speed = 30f;
        public Agent agentPrefab;
        public Color agentsColor = Color.white;
        public float radiusSize = 30f;
        public int numAgent = 100;


        private void Awake()
        {
            for (var i = 0; i < numAgent; i++)
            {
                Agent a = Instantiate(agentPrefab);
                agentSettings.agentName = agentSettings.agentBaseName + i;
                Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                agentSettings.position = pos;
                agentSettings.velocity = Random.insideUnitCircle;
                // agentSettings.speed = speed;
                // agentSettings.magnitudeForce = -10f;
                // agentSettings.magnitudeForceRadius = 5f;
                // agentSettings.color = Color.blue;
                a.SetAgent(agentSettings);
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