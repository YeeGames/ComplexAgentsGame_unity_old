using CAG2D_05.Scripts.Rules;
using UnityEngine;

namespace CAG2D_05.Scripts.YeeTypes
{
    public class YeeType : MonoBehaviour, IYeeType
    {
        private YeeTypeType yeeTypeType;
        private YeeType2E yeeType2E;
        private YeeType3E yeeType3E;

        public YeeTypeType GetYeeTypeType()
        {
            return yeeTypeType;
        }
    }

    /// <summary>
    /// Yee类型接口
    /// </summary>
    public interface IYeeType
    {
        /// <summary>
        /// 获取Yee类型
        /// </summary>
        /// <returns></returns>
        public YeeTypeType GetYeeTypeType();
    }

    /// <summary>
    /// Yee类型枚举
    /// </summary>
    public enum YeeTypeType
    {
        YeeType2E,
        YeeType3E
    }

    /// <summary>
    /// Yee 2元素类型枚举
    /// </summary>
    public enum YeeType2E
    {
        Yang,
        Yin
    }

    /// <summary>
    /// Yee 3元素类型枚举
    /// </summary>
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