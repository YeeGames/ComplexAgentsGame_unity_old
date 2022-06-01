using UnityEngine;

namespace CAG2D_05.Scripts.Settings
{
    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {
        public short dimention = 2;
        public int numAgent = 10;
        public int pauseTime = 0;
        public float wallRadiu = 100;
        public float wallWidth = 100;
        public float physicsMaterialsFriction = 0.0f;
        public float physicsMaterialsBounciness = 1.0f;
    }
}