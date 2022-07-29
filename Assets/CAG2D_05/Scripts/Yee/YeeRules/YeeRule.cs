// using CAG2D_05.Scripts.Rules;

using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class YeeRule : MonoBehaviour
    {
        private RuleSettings ruleSettings;
        private RuleSettings rset;
        private Yee3ETypeEnum _yee3ETypeEnum;
        private Yee3EInterTypeEnum _yee3EInterTypeEnum;

        private float forceStrength = 0f;

        private int direction = 1; // 方向取值1与-1。1表示推力方向，-1表示拉力方向；
        private float expCoefficient = 2f;
        private CircleCollider2D ruleCircleCollider2D;

        private Rigidbody2D rb1;
        private Rigidbody2D rb2;
        private Transform tf1;
        private Transform tf2;

        private GameSettings gameSettings;
        // private YeeTypeFamilyEnum _yeeTypeFamily;

        private Yee2ERule _yee2ERule;
        private Yee3ERule _yee3ERule;

        // public YeeTypeFamilyEnum GetTypeOfYeeTypeRule()
        // {
        //     this. = YeeTypeChooser.ChooseYeeRule(gset.yeeFamilyEnum);
        //     return this.yeeFamilyEnum;
        // }
        protected virtual void Initialize(RuleSettings ruleSettings)
        {
            SetRule(ruleSettings);
        }


        public virtual void SetRule(RuleSettings ruleSettings)
        {
            
        }


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

        public virtual void OnTriggerStay2D(Collider2D otherCollider2D)
        {
            
        }
    }
}