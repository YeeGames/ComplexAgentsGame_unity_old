using Unity.Mathematics;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class Yee3ERule : YeeRule /*,IYeeRule*/
    {
        private RuleSettings ruleSettings;
        private RuleSettings rset;
        private YeeType3E yeeType3E;
        private YeeTypeInter3E yeeTypeInter3E;

        private float forceStrength = 0f;

        private int direction = 1; // 方向取值1与-1。1表示推力方向，-1表示拉力方向；
        private Yee3ERule yee3ERule;
        private float expCoefficient = 2f;
        private CircleCollider2D ruleCircleCollider2D;

        private Rigidbody2D rb1;
        private Rigidbody2D rb2;
        private Transform tf1;
        private Transform tf2;

        private const int RowSize = 3;
        private const int ColSize = 3;

        /// <summary>
        /// 起始YeeType3E类型向量
        /// </summary>
        private YeeType3E[] fromYeeType3Es = new YeeType3E[]
        {
            YeeType3E.Rock, YeeType3E.Scissors, YeeType3E.Cloth
        };

        /// <summary>
        /// 目标YeeType3E类型向量
        /// </summary>
        private YeeType3E[] toYeeType3Es = new YeeType3E[]
        {
            YeeType3E.Rock, YeeType3E.Scissors, YeeType3E.Cloth
        };

        /// <summary>
        /// YeeTypeInter3E之规则之邻接矩阵
        /// </summary>
        private static readonly YeeTypeInter3E[,] yeeType3ERuleAdjecentMatrix = new YeeTypeInter3E[RowSize, ColSize]
        {
            {YeeTypeInter3E.Self, YeeTypeInter3E.Ke, YeeTypeInter3E.BeKe},
            {YeeTypeInter3E.BeKe, YeeTypeInter3E.Self, YeeTypeInter3E.Ke},
            {YeeTypeInter3E.Ke, YeeTypeInter3E.BeKe, YeeTypeInter3E.Self}
        };


        private void GetObject(Agent a1, Agent a2)
        {
        }

        public void Initialize(RuleSettings ruleSettings)
        {
            SetRuleSettings(ruleSettings);
        }

        public void SetRuleSettings(RuleSettings ruleSettings)
        {
            this.rset = ruleSettings;
            // this.rset = this.transform.GetComponent<YeeTypeFamily>();
            this.ruleCircleCollider2D.radius = this.rset.forceEffectiveRadius;
            this.forceStrength = this.rset.forceStrength;
            this.expCoefficient = this.rset.expCoefficient;
            this.direction = this.rset.direction;
            Debug.Log(this.rset.direction);
        }

        // /// <summary>
        // /// 设置行为规则
        // /// </summary>
        // public void SetBehaviorRule()
        // {
        // }


        /// <summary>
        /// 判断类型交互规则 
        /// </summary>
        /// <param name="thisYeeType3E">己方YeeType3E类型</param>
        /// <param name="thatYeeType3E">对方YeeType3E类型</param>
        public YeeTypeInter3E GetInterRule(YeeType3E thisYeeType3E, YeeType3E thatYeeType3E)
        {
            YeeTypeInter3E yeeTypeInter3E = yeeType3ERuleAdjecentMatrix[(int) thisYeeType3E, (int) thatYeeType3E];
            return yeeTypeInter3E;
        }


        /// <summary>
        /// 应用行为规则
        /// </summary>
        /// <param name="yeeTypeInter3E">YeeTypeInter3E类型</param>
        /// <param name="rb1">我方agent刚体</param>
        /// <param name="pos1">我方agent位置</param>
        /// <param name="rb2">对方agent刚体</param>
        /// <param name="pos2">对方agent位置</param>
        protected void ApplyBehaviorRule(YeeTypeInter3E yeeTypeInter3E, Rigidbody2D rb1, Vector2 pos1, Rigidbody2D rb2,
            Vector2 pos2)
        {
            Vector2 vector_from_a1_to_a2 = (Vector2) (pos2 - pos1);
            Vector2 direction_from_a1_to_a2 = vector_from_a1_to_a2.normalized;
            float distance_from_a1_to_a2 = direction_from_a1_to_a2.magnitude;


            // 应用施力规则。
            // 如果是交互状态我方为Ke，则己方受到拉力，对方受到推力，形成效果力之于己方追逐对方逃避；
            // 如果是交互状态我方为BeKe，则己方受到推力，对方受到拉力，形成效果力之于对方追逐我方逃避；
            if (yeeTypeInter3E == YeeTypeInter3E.Ke)
            {
                rb1.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient), ForceMode2D.Force);
                rb2.AddForce(
                    forceStrength * ((float) -direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
            }
            else if (yeeTypeInter3E == YeeTypeInter3E.BeKe)
            {
                rb1.AddForce(
                    forceStrength * ((float) -direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
                rb2.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
            }
        }


        private void Awake()
        {
            this.rset = this.ruleSettings;
            this.ruleCircleCollider2D = GameObject.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            Initialize(rset);
        }


        protected override void SetRule(RuleSettings ruleSettings)
        {
            this.rset = ruleSettings;
            // this.rset = this.transform.GetComponent<YeeTypeFamily>();
            this.ruleCircleCollider2D.radius = this.rset.forceEffectiveRadius;
            this.forceStrength = this.rset.forceStrength;
            this.expCoefficient = this.rset.expCoefficient;
            this.direction = this.rset.direction;
            Debug.Log(this.rset.direction);
        }

        public override void OnTriggerStay2D(Collider2D otherCollider2D)
        {
            Rigidbody2D thisRigidbody2D = this.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 thisPosition2D = this.gameObject.transform.GetComponentInParent<Transform>().position;
            YeeType3E thisYeeType3E = this.gameObject.transform.GetComponentInParent<Agent>().yeeType3E;
            Rigidbody2D thatRigidbody2D = otherCollider2D.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 thatPosition2D = otherCollider2D.gameObject.transform.GetComponentInParent<Transform>().position;
            YeeType3E thatYeeType3E = otherCollider2D.gameObject.transform.GetComponentInParent<Agent>().yeeType3E;
            this.yeeTypeInter3E = GetInterRule(thisYeeType3E, thatYeeType3E);
            ApplyBehaviorRule(this.yeeTypeInter3E, thisRigidbody2D, thisPosition2D, thatRigidbody2D, thatPosition2D);
        }
    }
}