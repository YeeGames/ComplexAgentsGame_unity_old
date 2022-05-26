using UnityEngine;

namespace CAG2D_04.Scripts
{
    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {
        // public AgentSettings agentSettings;
        public short dimention = 2;
        public int numAgent = 10;
        public int pauseTime = 0;
        public float wallRadiu = 100;
        public float wallWidth = 100;
        public float physicsMaterialsFriction = 0.0f;
        public float physicsMaterialsBounciness = 1.0f;
    }
}