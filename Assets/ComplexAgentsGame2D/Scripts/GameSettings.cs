using UnityEngine;

namespace ComplexAgentsGame2D.Scripts
{
    [CreateAssetMenu]
    public class GameSettings : ScriptableObject
    {
        public short dimention = 2;

        public int numAgent = 10;
        public Color color = Color.red;

        public enum Team : short
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
            K,
            L,
            M,
            N,
            O,
            P,
            Q,
            R,
            S,
            T,
            U,
            V,
            W,
            X,
            Y,
            Z
        }
    }
}