using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace ComplexAgentsGame2D.Scripts
{
    [CreateAssetMenu]
    public class AgentSettings : ScriptableObject
    {
        // public GameSettings gameSettings;

        // public GameSettings gameSettings;
        public float mass = 1f;
        public float energy = 1f;
        public Vector2 position = new Vector2(0f, 0f);
        public Vector2 velocity = new Vector2(0f, 0f);
        public float speed = 1f;
        public Vector2 acceleration = new Vector2(0f, 0f);
        public Vector2 momentum = new Vector2(0f, 0f);
        public Color color = Color.blue;
        public float size = 10f;
        public Team team;
        public YeeType yeeType;
    }
}