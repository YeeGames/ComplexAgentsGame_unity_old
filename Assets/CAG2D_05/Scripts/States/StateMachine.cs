namespace CAG2D_05.Scripts.States
{
    /// <summary>
    /// 有限状态机，主要借鉴《游戏人工智能编程案例精粹（修订版）》、[Unity 中用有限状态机来实现一个 AI](https://blog.csdn.net/weixin_33811961/article/details/88668257?spm=1001.2101.3001.6661.1&utm_medium=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7ECTRLIST%7Edefault-1-88668257-blog-122858387.pc_relevant_aa&depth_1-utm_source=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7ECTRLIST%7Edefault-1-88668257-blog-122858387.pc_relevant_aa&utm_relevant_index=1)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StateMachine<T>
    {
        private T m_pOwner;
        private InterState<T> mPCurrentInterState;
        private InterState<T> mPPreviousInterState;
        private InterState<T> mPGlobalInterState;

        public StateMachine(T owner)
        {
            m_pOwner = owner;
        }

        public void SetCurrentState(InterState<T> interState)
        {
            mPCurrentInterState = interState;
        }

        public void SetPreviousState(InterState<T> interState)
        {
            mPPreviousInterState = interState;
        }

        public void SetGlobalState(InterState<T> interState)
        {
            mPGlobalInterState = interState;
        }

        public void StateMachineUpdate()
        {
            // 如果有一个全局状态存在，调用它的执行方法
            if (mPGlobalInterState != null)
            {
                mPGlobalInterState.Execute(m_pOwner);
            }

            if (mPCurrentInterState != null)
            {
                mPCurrentInterState.Execute(m_pOwner);
            }
        }

        public void ChangeState(InterState<T> newInterState)
        {
            mPPreviousInterState = mPCurrentInterState;
            mPCurrentInterState.Exit(m_pOwner);
            mPCurrentInterState = newInterState;
            mPCurrentInterState.Enter(m_pOwner);
        }

        /// <summary>
        /// 返回之前的状态
        /// </summary>
        public void RevertToPreviousState()
        {
            ChangeState(mPPreviousInterState);
        }

        public InterState<T> CurrentState()
        {
            return mPCurrentInterState;
        }

        public InterState<T> PreviousState()
        {
            return mPPreviousInterState;
        }

        public InterState<T> GlobalState()
        {
            return mPGlobalInterState;
        }

        public bool IsInState(InterState<T> interState)
        {
            return mPCurrentInterState == interState;
        }
    }
}