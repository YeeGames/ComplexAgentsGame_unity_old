using UnityEngine;

namespace CAG2D_01.Scripts
{
    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {
        public AgentSettings agentSettings;
        public short dimention = 2;
        public int numAgent = 10;
        public int pauseTime = 0;
    }
}