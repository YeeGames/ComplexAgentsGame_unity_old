using UnityEngine;

namespace CAG2D_04.Scripts
{
    [CreateAssetMenu]
    public class RuleSettings : ScriptableObject
    {
        // public float forceStrength = 1f;
        public float forceStrength = 10f; // 力场强度；
        public float forceEffectiveRadius = 2.5f; // 力场影响半径；
        public float expCoefficient = 2f; // 力场衰减指数系数；
        public int direction = 1;


    }
}