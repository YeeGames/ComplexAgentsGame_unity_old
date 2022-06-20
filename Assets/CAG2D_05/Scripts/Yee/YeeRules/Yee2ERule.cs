using Unity.Mathematics;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class Yee2ERule : YeeRule
    {
        private RuleSettings ruleSettings;
        private RuleSettings rset;
        private float forceStrength = 0f;
        private YeeType2E yeeType2E;
        private YeeTypeInter2E yeeTypeInter2E;

        private int direction = 1;
        private float expCoefficient = 2f;
        private CircleCollider2D ruleCircleCollider2D;

        private Rigidbody2D rb1;
        private Rigidbody2D rb2;
        private Transform tf1;
        private Transform tf2;

        private const int RowSize = 2;
        private const int ColSize = 2;

        private void GetObject(Agent a1, Agent a2)
        {
        }

        protected override void Initialize(RuleSettings ruleSettings)
        {
            SetRule(ruleSettings);
        }

        public YeeTypeFamily GetTypeOfYeeTypeRule()
        {
            return YeeTypeFamily.YeeType2E;
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

        /// <summary>
        /// YeeTypeInter2E之规则之邻接矩阵
        /// </summary>
        private static readonly YeeTypeInter2E[,] yeeType2ERuleAdjecentMatrix = new YeeTypeInter2E[RowSize, ColSize]
        {
            {YeeTypeInter2E.Me, YeeTypeInter2E.You},
            {YeeTypeInter2E.You, YeeTypeInter2E.Me},
        };

        public YeeTypeInter2E GetInterRule(YeeType2E thisYeeType2E, YeeType2E thatYeeType2E)
        {
            YeeTypeInter2E yeeTypeInter2E = yeeType2ERuleAdjecentMatrix[(int) thisYeeType2E, (int) thatYeeType2E];
            return yeeTypeInter2E;
        }


        protected void ApplyBehaviorRule(YeeTypeInter2E yeeTypeInter2E, Rigidbody2D rb1, Vector2 pos1,
            Rigidbody2D rb2,
            Vector2 pos2
        )
        {
            Vector2 vector_from_a1_to_a2 = (Vector2) (pos2 - pos1);
            Vector2 direction_from_a1_to_a2 = vector_from_a1_to_a2.normalized;
            float distance_from_a1_to_a2 = direction_from_a1_to_a2.magnitude;
            if (yeeTypeInter2E == YeeTypeInter2E.Me)
            {
                rb1.AddForce(
                    forceStrength * (-(float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient), ForceMode2D.Force);
                rb2.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
            }
            else if (yeeTypeInter2E == YeeTypeInter2E.You)
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
        // protected override void ApplyBehaviorRule(YeeType t1, YeeType t2, Rigidbody2D rb1, Vector2 pos1,
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
            this.rset = this.ruleSettings;
            this.ruleCircleCollider2D = GameObject.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            Initialize(rset);
        }

        public override void OnTriggerStay2D(Collider2D otherCollider2D)
        {
            Rigidbody2D thisRigidbody2D = this.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 thisPosition2D = this.gameObject.transform.GetComponentInParent<Transform>().position;
            YeeType2E thisYeeType2E = this.gameObject.transform.GetComponentInParent<Agent>().yeeType2E;
            Rigidbody2D thatRigidbody2D = otherCollider2D.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 thatPosition2D = otherCollider2D.gameObject.transform.GetComponentInParent<Transform>().position;
            YeeType2E thatYeeType2E = otherCollider2D.gameObject.transform.GetComponentInParent<Agent>().yeeType2E;
            this.yeeTypeInter2E = GetInterRule(thisYeeType2E, thatYeeType2E);
            ApplyBehaviorRule(this.yeeTypeInter2E, thisRigidbody2D, thisPosition2D, thatRigidbody2D, thatPosition2D);
        }
    }
}