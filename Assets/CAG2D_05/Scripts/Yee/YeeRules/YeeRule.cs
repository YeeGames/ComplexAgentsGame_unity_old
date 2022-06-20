// using CAG2D_05.Scripts.Rules;

using UnityEngine;
using CAG2D_05.Scripts;

namespace CAG2D_05.Scripts
{
    public abstract class YeeRule : MonoBehaviour
    {
        private RuleSettings ruleSettings;
        private RuleSettings rset;
        private YeeType3E yeeType3E;
        private YeeTypeInter3E yeeTypeInter3E;

        private float forceStrength = 0f;

        private int direction = 1; // 方向取值1与-1。1表示推力方向，-1表示拉力方向；
        private float expCoefficient = 2f;
        private CircleCollider2D ruleCircleCollider2D;

        private Rigidbody2D rb1;
        private Rigidbody2D rb2;
        private Transform tf1;
        private Transform tf2;

        private GameSettings gameSettings;
        private YeeTypeFamily yeeTypeFamily;

        private Yee2ERule yee2ERule;
        private Yee3ERule yee3ERule;

        // public YeeTypeFamily GetTypeOfYeeTypeRule()
        // {
        //     this. = YeeTypeChooser.ChooseYeeType(gameSettings.yeeTypeFamily);
        //     return this.yeeTypeFamily;
        // }
        protected virtual void Initialize(RuleSettings ruleSettings)
        {
            SetRule(ruleSettings);
        }


        protected abstract void SetRule(RuleSettings ruleSettings);


        protected void ApplyBehaviorRule()
        {
        }

        // protected abstract void ApplyBehaviorRule();
        
        private void Awake()
        {
            this.rset = this.ruleSettings;
            this.ruleCircleCollider2D = GameObject.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            Initialize(rset);
        }

        public abstract void OnTriggerStay2D(Collider2D otherCollider2D);
    }
}