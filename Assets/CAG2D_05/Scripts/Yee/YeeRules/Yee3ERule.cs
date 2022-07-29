using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class Yee3ERule : YeeRule
    {
        private RuleSettings rset;

        private YeeFamily _yeeFamily;
        private static Yee3E _yee3E;
        private Yee _yee;
        private string _yeeInterType;


        private float forceStrength = 0f;
        private int direction = 1; // 方向取值1与-1。1表示推力方向，-1表示拉力方向；
        private Yee3ERule _yee3ERule;
        private float expCoefficient = 2f;
        private CircleCollider2D ruleCircleCollider2D;

        private Rigidbody2D rb1;
        private Rigidbody2D rb2;
        private Transform tf1;
        private Transform tf2;


        /// <summary>
        /// 起始Yee3EType向量
        /// </summary>
        private string[] fromYee3ETypeArray = new string[]
        {
            _yee3E.YeeTypes[0], _yee3E.YeeTypes[1], _yee3E.YeeTypes[2]
        };
        // private Yee3ETypeEnum[] fromYee3ETypeArray = new Yee3ETypeEnum[]
        // {

        //     Yee3ETypeEnum.Rock, Yee3ETypeEnum.Scissors, Yee3ETypeEnum.Cloth
        // };

        /// <summary>
        /// 目标Yee3EType向量
        /// </summary>
        private string[] toYee3ETypeArray = new string[]
        {
            _yee3E.YeeTypes[0], _yee3E.YeeTypes[1], _yee3E.YeeTypes[2]
        };
        // private Yee3ETypeEnum[] toYee3ETypeArray = new Yee3ETypeEnum[]
        // {
        //     Yee3ETypeEnum.Rock, Yee3ETypeEnum.Scissors, Yee3ETypeEnum.Cloth
        // };

        /// <summary>
        /// Yee3ETypeInter之规则之邻接矩阵
        /// </summary>
        private static readonly string[,] yee3ERuleAdjecentMatrix = new string[3, 3]
        {
            {_yee3E.YeeInterTypes[0], _yee3E.YeeInterTypes[1], _yee3E.YeeInterTypes[2]},
            {_yee3E.YeeInterTypes[2], _yee3E.YeeInterTypes[0], _yee3E.YeeInterTypes[1]},
            {_yee3E.YeeInterTypes[1], _yee3E.YeeInterTypes[0], _yee3E.YeeInterTypes[2]},
        };
        // private static readonly Yee3EInterTypeEnum[,] yee3ERuleAdjecentMatrix = new Yee3EInterTypeEnum[RowSize, ColSize]
        // {
        //     {Yee3EInterTypeEnum.Self, Yee3EInterTypeEnum.Ke, Yee3EInterTypeEnum.BeKe},
        //     {Yee3EInterTypeEnum.BeKe, Yee3EInterTypeEnum.Self, Yee3EInterTypeEnum.Ke},
        //     {Yee3EInterTypeEnum.Ke, Yee3EInterTypeEnum.BeKe, Yee3EInterTypeEnum.Self}
        // };


        protected override void Initialize(RuleSettings ruleSettings)
        {
            SetRule(ruleSettings);
        }

        /// <summary>
        /// 设置规则
        /// </summary>
        /// <param name="ruleSettings"></param>
        public override void SetRule(RuleSettings ruleSettings)
        {
            this.rset = ruleSettings;
            // this.rset = this.transform.GetComponent<YeeTypeFamilyEnum>();
            this.ruleCircleCollider2D.radius = this.rset.forceEffectiveRadius;
            this.forceStrength = this.rset.forceStrength;
            this.expCoefficient = this.rset.expCoefficient;
            this.direction = this.rset.direction;
            Debug.Log(this.rset.direction);
        }


        /// <summary>
        /// 判断类型交互规则 
        /// </summary>
        /// <param name="thisYeeType">己方YeeType3E类型</param>
        /// <param name="thatYeeType">对方YeeType3E类型</param>
        public string GetInterRule(string thisYeeType, string thatYeeType)
        {
            string yeeInterType = yee3ERuleAdjecentMatrix[Array.IndexOf(fromYee3ETypeArray, thisYeeType), Array.IndexOf(toYee3ETypeArray, thatYeeType)];
            return yeeInterType;
        }


        /// <summary>
        /// 应用行为规则
        /// </summary>
        /// <param name="yeeInterType">YeeTypeInter3E类型</param>
        /// <param name="rb1">我方agent刚体</param>
        /// <param name="pos1">我方agent位置</param>
        /// <param name="rb2">对方agent刚体</param>
        /// <param name="pos2">对方agent位置</param>
        protected void ApplyBehaviorRule(string yeeInterType, Rigidbody2D rb1, Vector2 pos1, Rigidbody2D rb2,
            Vector2 pos2)
        {
            Vector2 vector_from_a1_to_a2 = (Vector2) (pos2 - pos1);
            Vector2 direction_from_a1_to_a2 = vector_from_a1_to_a2.normalized;
            float distance_from_a1_to_a2 = direction_from_a1_to_a2.magnitude;


            // 应用施力规则。
            // 如果是交互状态我方为Ke，则己方受到拉力，对方受到推力，形成效果力之于己方追逐对方逃避；
            // 如果是交互状态我方为BeKe，则己方受到推力，对方受到拉力，形成效果力之于对方追逐我方逃避；
            if (yeeInterType == Yee3EInterTypeEnum.Ke.ToString())
            {
                rb1.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient), ForceMode2D.Force);
                rb2.AddForce(
                    forceStrength * ((float) -direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
            }
            else if (yeeInterType == Yee3EInterTypeEnum.BeKe.ToString())
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


        protected void ApplyBehaviorRule()
        {
            throw new System.NotImplementedException();
        }

        private void Awake()
        {
            this.ruleCircleCollider2D = GameObject.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            Initialize(rset);
        }


        public override void OnTriggerStay2D(Collider2D otherCollider2D)
        {
            Rigidbody2D thisRigidbody2D = this.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 thisPosition2D = this.gameObject.transform.GetComponentInParent<Transform>().position;
            string thisYeeType = this.gameObject.transform.GetComponentInParent<Agent>().aset.YeeType;
            // string thisYeeInterType = this.gameObject.transform.GetComponentInParent<Agent>().aset.YeeInterTypes;
            Rigidbody2D thatRigidbody2D = otherCollider2D.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 thatPosition2D = otherCollider2D.gameObject.transform.GetComponentInParent<Transform>().position;
            // Yee3ETypeEnum thatYeeType = otherCollider2D.gameObject.transform.GetComponentInParent<Agent>().yee3ETypeEnum;
            // yeeFamilyEnum thatYeeFamily = otherCollider2D.gameObject.transform.GetComponent<yee>().yeeFamilyEnum;
            string thatYeeType = otherCollider2D.gameObject.transform.GetComponentInParent<Agent>().aset.YeeType;
            // List<string> thatYeeType = _yeeFamily.YeeTypes;
            // this._yee3EInterTypeEnum = GetInterRule(thisYeeFamily.YeeTypes[1], thatYeeType);
            _yeeInterType = GetInterRule(thisYeeType, thatYeeType);
            ApplyBehaviorRule(_yeeInterType, thisRigidbody2D, thisPosition2D, thatRigidbody2D, thatPosition2D);
        }
    }
}