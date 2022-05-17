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
                Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                Agent a = Instantiate(agentPrefab);
                a.name = "agent " + i;
                a.SetPosition(pos);
                a.velocity = Random.insideUnitCircle;
                a.speed = speed;
                a.SetVelocity(a.velocity, a.speed);
                a.SetColor(agentsColor);
                a.magnitudeForce = 10f;
                a.magnitudeForceRadius = 5f;
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