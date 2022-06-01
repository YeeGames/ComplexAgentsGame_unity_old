namespace CAG2D_05.Scripts.States
{
    public abstract class InterState<T>
    {
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
    }


}