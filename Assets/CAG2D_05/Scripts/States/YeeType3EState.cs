using CAG2D_05.Scripts.YeeTypes;
using Unity.VisualScripting;
using UnityEngine;

namespace CAG2D_05.Scripts.States
{
    public abstract class YeeType3EState<T> : MonoBehaviour
    {
        public YeeType3E[] yeeType3Es =
        {
            YeeType3E.Rock, YeeType3E.Scissors, YeeType3E.Scissors
        };


        /// <summary>
        /// agent进入状态时
        /// </summary>
        public abstract void Enter(T a);

        /// <summary>
        /// agent更新状态时
        /// </summary>
        public abstract void Execute(T a);

        /// <summary>
        /// agent退出状态时
        /// </summary>
        public abstract void Exit(T a);

        public abstract void OnTriggerStay(Collider2D otherCollider2D);
    }
}