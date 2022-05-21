using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace CAG2D_04.Scripts
{
    [CreateAssetMenu]
    public class AgentSettings : ScriptableObject
    {
        private GameSettings gameSettings;
        
        public string agentBaseName;
        [HideInInspector] public string agentName;
        public bool isMovable = true;
        public Color color = Color.white;
        public float mass = 1f;
        public float size = 10f;
        public float linearDrag = 0;
        public float angleDrag = 0;
        public float collisionRadius = 0.5f;
        public Vector2 position;
        public Vector2 velocity = new Vector2(0, 0);
        public float speed = 0f;
        public float magnitudeForce = -10f;
        public float magnitudeForceRadius = 5f;
        public float physicsMaterialFriction = 0.0f;
        public float physicsMaterialBounciness = 1.0f;
        public YeeType2Y yeeType2Y;
        public YeeTypeAR yeeTypeAR;
        [HideInInspector] public float energy = 1f;
        [HideInInspector] public Vector2 acceleration;
        [HideInInspector] public Vector2 momentum;
    }
}