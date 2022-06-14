using Unity.Mathematics;
using UnityEngine;

namespace CAG2D_05.Scripts.Rules
{
    public class YeeTypeRule : MonoBehaviour, IYeeTypeRule
    {
        private YeeTypeRuleType yeeTypeRuleType;

        private YeeType2ERule yeeType2ERule;
        private YeeType3ERule yeeType3ERule;

        public YeeTypeRuleType GetRuleType()
        {
            return yeeTypeRuleType;
        }

        public void SetRule(RuleSettings ruleSettings)
        {
            switch (yeeTypeRuleType)
            {
                case YeeTypeRuleType.YeeType2ERule:
                    yeeType2ERule.SetRule(ruleSettings);
                    break;
                case YeeTypeRuleType.YeeType3ERule:
                    yeeType3ERule.SetRule(ruleSettings);
                    break;
                default:
                    break;
            }
        }
    }

    public interface IYeeTypeRule
    {
        public YeeTypeRuleType GetRuleType();
        public void SetRule(RuleSettings ruleSettings);
    }


    public enum YeeTypeRuleType
    {
        YeeType2ERule,
        YeeType3ERule
    }
}