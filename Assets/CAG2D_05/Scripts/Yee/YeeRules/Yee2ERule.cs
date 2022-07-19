using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class Yee2ERule : YeeRule
    {
        private RuleSettings rset;

        private YeeFamily _yeeFamily;
        private static Yee2E _yee2E;
        private Yee _yee;

        private string _yeeInterType;


        private float forceStrength = 0f;
        private int direction = 1; // 方向取值1与-1。1表示推力方向，-1表示拉力方向；
        private float expCoefficient = 2f;
        private CircleCollider2D ruleCircleCollider2D;

        private Rigidbody2D rb1;
        private Rigidbody2D rb2;
        private Transform tf1;
        private Transform tf2;


        /// <summary>
        /// 起始Yee2EType向量
        /// </summary>
        private string[] fromYee2ETypeArray = new string[]
        {
            _yee2E.YeeTypes[0], _yee2E.YeeTypes[1]
        };


        /// <summary>
        /// 目标Yee2EType向量
        /// </summary>
        private string[] toYee2ETypeArray = new string[]
        {
            _yee2E.YeeTypes[0], _yee2E.YeeTypes[1]
        };


        /// <summary>
        /// Yee2ETypeInter之规则之邻接矩阵
        /// </summary>
        private static readonly string[,] yee2ERuleAdjecentMatrix = new string[2, 2]
        {
            {_yee2E.YeeInterTypes[0], _yee2E.YeeInterTypes[1]},
            {_yee2E.YeeInterTypes[1], _yee2E.YeeInterTypes[0]},
        };

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


        public string GetInterRule(string thisYeeType, string thatYeeType)
        {
            string yeeInterType = yee2ERuleAdjecentMatrix[Array.IndexOf(fromYee2ETypeArray, thisYeeType), Array.IndexOf(toYee2ETypeArray, thatYeeType)];
            return yeeInterType;
        }


        protected void ApplyBehaviorRule(string yeeInterType, Rigidbody2D rb1, Vector2 pos1,
            Rigidbody2D rb2,
            Vector2 pos2
        )
        {
            Vector2 vector_from_a1_to_a2 = (Vector2) (pos2 - pos1);
            Vector2 direction_from_a1_to_a2 = vector_from_a1_to_a2.normalized;
            float distance_from_a1_to_a2 = direction_from_a1_to_a2.magnitude;
            if (yeeInterType == Yee2EInterTypeEnum.Me.ToString())
            {
                rb1.AddForce(
                    forceStrength * (-(float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient), ForceMode2D.Force);
                rb2.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
            }
            else if (yeeInterType == Yee2EInterTypeEnum.You.ToString())
            {
                rb1.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
                rb2.AddForce(
                    forceStrength * (-(float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
            }
        }
        // protected override void ApplyBehaviorRule(YeeTypeFamilyEnum t1, YeeTypeFamilyEnum t2, Rigidbody2D rb1, Vector2 pos1,
        //     Rigidbody2D rb2,
        //     Vector2 pos2
        // )
        // {
        //     Vector2 vector_from_a1_to_a2 = (Vector2) (pos2 - pos1);
        //     Vector2 direction_from_a1_to_a2 = vector_from_a1_to_a2.normalized;
        //     float distance_from_a1_to_a2 = direction_from_a1_to_a2.magnitude;
        //     if (t1 == t2)
        //     {
        //         rb1.AddForce(
        //             forceStrength * (-(float) direction * direction_from_a1_to_a2) /
        //             math.pow(distance_from_a1_to_a2, expCoefficient), ForceMode2D.Force);
        //         rb2.AddForce(
        //             forceStrength * ((float) direction * direction_from_a1_to_a2) /
        //             math.pow(distance_from_a1_to_a2, expCoefficient),
        //             ForceMode2D.Force);
        //     }
        //     else
        //     {
        //         rb1.AddForce(
        //             forceStrength * ((float) direction * direction_from_a1_to_a2) /
        //             math.pow(distance_from_a1_to_a2, expCoefficient),
        //             ForceMode2D.Force);
        //         rb2.AddForce(
        //             forceStrength * (-(float) direction * direction_from_a1_to_a2) /
        //             math.pow(distance_from_a1_to_a2, expCoefficient),
        //             ForceMode2D.Force);
        //     }
        // }


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
            Rigidbody2D thatRigidbody2D = otherCollider2D.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 thatPosition2D = otherCollider2D.gameObject.transform.GetComponentInParent<Transform>().position;
            string thatYeeType = otherCollider2D.gameObject.transform.GetComponentInParent<Agent>().aset.YeeType;
            _yeeInterType = GetInterRule(thisYeeType, thatYeeType);
            ApplyBehaviorRule(_yeeInterType, thisRigidbody2D, thisPosition2D, thatRigidbody2D, thatPosition2D);
        }
    }
}