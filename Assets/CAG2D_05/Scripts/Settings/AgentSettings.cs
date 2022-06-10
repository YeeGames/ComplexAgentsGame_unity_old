using CAG2D_05.Scripts.YeeTypes;
using UnityEngine;

namespace CAG2D_05.Scripts.Settings
{
    [CreateAssetMenu]
    public class AgentSettings : ScriptableObject
    {
        private GameSettings gameSettings;

        public string agentBaseName = "thisAgent";
        [HideInInspector] public string agentName;
        [HideInInspector] public bool isMovable = true;
        public Color color = Color.white;
        public float mass = 1f;
        public float size = 10f;
        public float linearDrag = 0;
        public float angularDrag = 0;
        public float collisionRadius = 0.5f;
        public Vector2 position;
        public Vector2 velocity = new Vector2(0, 0);
        public float maxSpeed = 20f;
        public float maxAngularSpeed = 20f;
        public float initSpeed = 0f;
        public float magnitudeForce = -10f;
        public float magnitudeForceRadius = 5f;
        public float physicsMaterialFriction = 0.0f;
        public float physicsMaterialBounciness = 1.0f;
        public YeeType2E yeeType2E = YeeType2E.Yang;
        [HideInInspector] public float energy = 1f;
        [HideInInspector] public Vector2 acceleration;
        [HideInInspector] public Vector2 momentum;
    }
}