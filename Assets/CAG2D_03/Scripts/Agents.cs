using UnityEngine;
using Random = UnityEngine.Random;

namespace CAG2D_03.Scripts
{
    public class Agents : MonoBehaviour
    {
        public GameSettings gameSettings;
        public AgentSettings agentSettings;
        public Agent agentPrefab;
        public float radiusSize = 30f;


        private void Awake()
        {
            for (var i = 0; i < gameSettings.numAgent; i++)
            {
                Agent a = Instantiate(agentPrefab);
                agentSettings.agentName = agentSettings.agentBaseName + i;
                Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                agentSettings.position = pos;
                agentSettings.velocity = Random.insideUnitCircle;
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