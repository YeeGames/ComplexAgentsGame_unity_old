using UnityEngine;

public class AgentSettings : MonoBehaviour
{
    public enum ChingType
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

    public float mass;
    public float energy;
    public Vector2 position;
    public Vector2 velocity;
    public Vector2 acceleration;
    public Vector2 momentum;

    public enum Stand
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

    public Color color;
}