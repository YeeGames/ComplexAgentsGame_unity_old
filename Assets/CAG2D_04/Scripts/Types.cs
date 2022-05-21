using UnityEngine;

namespace CAG2D_04.Scripts
{
    public class YeeType : MonoBehaviour
    {
        public YeeType2Y yeeType2E;
        public YeeTypeAR yeeTypeAR;
    }

    public enum YeeType2Y : short
    {
        Yang,
        Yin
    }

    /// <summary>
    /// 吸引力、排斥力
    /// </summary>
    public enum YeeTypeAR : short
    {
        AttractiveForce,
        RepulsiveForce
    }
}