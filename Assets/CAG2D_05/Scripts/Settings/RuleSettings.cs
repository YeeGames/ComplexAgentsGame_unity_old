using CAG2D_05.Scripts.YeeTypes;
using UnityEngine;

namespace CAG2D_05.Scripts.Rules
{
    [CreateAssetMenu]
    public class RuleSettings : ScriptableObject
    {
        public YeeType yeeType;
        public Rules rules;
        // public bool isEnableForce;
        public float forceStrength = 10f; // 力场强度；
        public float forceEffectiveRadius = 2.5f; // 力场影响半径；
        public float expCoefficient = 2f; // 力场衰减指数系数；
        public int direction = 1;
    }
}