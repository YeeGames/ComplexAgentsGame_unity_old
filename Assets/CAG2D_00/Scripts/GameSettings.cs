using UnityEngine;
using CAG2D_00.Scripts;

namespace CAG2D_00.Scripts
{
    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {
        public short dimention = 2;
        public int numAgent = 10;
        public int pauseTime = 0;
        public float wallRadiu = 100;
        public float wallWidth = 100;
    }
}