using UnityEngine;

namespace CAG2D_00.Scripts
{
    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {
        public short dimention = 2;

        public int numAgent = 10;
        public Color color = Color.red;
    }
}