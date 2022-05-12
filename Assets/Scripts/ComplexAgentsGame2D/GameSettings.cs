using System;
using UnityEngine;

namespace ComplexAgentsGame2D
{
    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {
        public int dimention = 2;
        public int numOfAgent = 10;
        public Color color = Color.red;
    }
}