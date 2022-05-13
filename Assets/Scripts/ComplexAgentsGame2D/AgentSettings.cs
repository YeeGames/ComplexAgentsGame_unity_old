using UnityEngine;

namespace ComplexAgentsGame2D
{
    [CreateAssetMenu]
    public class AgentSettings : ScriptableObject
    {
        // public GameSettings gameSettings;
        public enum ElementsChangeType
        {
            Yi,
            Yin,
            Yang,
            Tian,
            Ren,
            Di,
            Mu,
            Huo,
            Tu,
            Jin,
            Shui,
            Qian,
            Kun,
            Zhen,
            Xun,
            Kan,
            Li,
            Gen,
            Dui
        }

        public float mass = 1f;
        public float energy;
        public Vector2 position;
        public Vector2 velocity;
        public float speed = 1f;
        public Vector2 acceleration;
        public Vector2 momentum;

        public enum Team
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

        public Color color = Color.blue;
    }
}