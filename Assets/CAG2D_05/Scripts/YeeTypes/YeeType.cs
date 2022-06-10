using UnityEngine;

namespace CAG2D_05.Scripts.YeeTypes
{
    public class YeeType : MonoBehaviour
    {
        public YeeType2E yeeType2E;
        public YeeType3E yeeType3E;
    }


    public enum YeeType2E
    {
        Yang,
        Yin
    }

    public enum YeeType3E
    {
        Rock,
        Scissors,
        Cloth
    }

    public enum YeeTypeInter3E
    {
        Self,
        Ke,
        BeKe
    }
}