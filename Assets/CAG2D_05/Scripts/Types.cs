using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class YeeType : MonoBehaviour
    {
        public YeeType2E yeeType2E;
    }

    
    public enum YeeType2E : short
    {
        Yang,
        Yin
    }

    public enum YeeType3E : short
    {
        Rock,
        Scissors,
        Cloth
    }

}