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
        
        private static YeeFamily _yeeFamily;
        private static Yee3E _yee3E;

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

        // private Yee2ERule _yee2ERule;
        // private Yee3ERule _yee3ERule;

        
        /// <summary>
        /// 起始YeeType向量
        /// </summary>
        public string[] fromYeeTypeArray = new string[]
        {
        };
        
        /// <summary>
        /// 目标YeeType向量
        /// </summary>
        public string[] toYeeTypeArray = new string[]
        {
        };
        
        /// <summary>
        /// YeeTypeInter之规则之邻接矩阵
        /// </summary>
        public string[,] yeeRuleAdjecentMatrix = new string[,]
        {
        };
        
        
        // /// <summary>
        // /// 起始YeeType向量
        // /// </summary>
        // public string[] fromYeeTypeArray = 
        // {
        //     YeeFamily.YeeTypes[0], YeeFamily.YeeTypes[1], YeeFamily.YeeTypes[2]
        // };
        // // private Yee3ETypeEnum[] fromYeeTypeArray = new Yee3ETypeEnum[]
        // // {
        //
        // //     Yee3ETypeEnum.Rock, Yee3ETypeEnum.Scissors, Yee3ETypeEnum.Cloth
        // // };
        //
        // /// <summary>
        // /// 目标YeeType向量
        // /// </summary>
        // public string[] toYeeTypeArray = 
        // {
        //     Yee3E.YeeTypes[0], Yee3E.YeeTypes[1], Yee3E.YeeTypes[2]
        // };
        // // private Yee3ETypeEnum[] toYeeTypeArray = new Yee3ETypeEnum[]
        // // {
        // //     Yee3ETypeEnum.Rock, Yee3ETypeEnum.Scissors, Yee3ETypeEnum.Cloth
        // // };
        //
        // /// <summary>
        // /// YeeTypeInter之规则之邻接矩阵
        // /// </summary>
        // public string[,] yeeRuleAdjecentMatrix = 
        // {
        //     {Yee3E.YeeInterTypes[0], Yee3E.YeeInterTypes[1], Yee3E.YeeInterTypes[2]},
        //     {Yee3E.YeeInterTypes[2], Yee3E.YeeInterTypes[0], Yee3E.YeeInterTypes[1]},
        //     {Yee3E.YeeInterTypes[1], Yee3E.YeeInterTypes[0], Yee3E.YeeInterTypes[2]},
        // };
        // // private static readonly Yee3EInterTypeEnum[,] yeeRuleAdjecentMatrix = new Yee3EInterTypeEnum[RowSize, ColSize]
        // // {
        // //     {Yee3EInterTypeEnum.Self, Yee3EInterTypeEnum.Ke, Yee3EInterTypeEnum.BeKe},
        // //     {Yee3EInterTypeEnum.BeKe, Yee3EInterTypeEnum.Self, Yee3EInterTypeEnum.Ke},
        // //     {Yee3EInterTypeEnum.Ke, Yee3EInterTypeEnum.BeKe, Yee3EInterTypeEnum.Self}
        // // };



        public virtual void SetRule(RuleSettings ruleSettings)
        {
            
        }

                
        protected virtual void Initialize(RuleSettings ruleSettings)
        {
            SetRule(ruleSettings);
            
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