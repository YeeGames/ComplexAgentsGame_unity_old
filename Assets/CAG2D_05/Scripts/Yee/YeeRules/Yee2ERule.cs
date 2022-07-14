using Unity.Mathematics;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class Yee2ERule : YeeRule
    {
        private RuleSettings ruleSettings;
        private RuleSettings rset;
        private float forceStrength = 0f;
        private Yee2ETypeEnum _yee2ETypeEnum;
        private Yee2EInterTypeEnum _yee2EInterTypeEnum;

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

        public YeeTypeFamilyEnum GetTypeOfYeeTypeRule()
        {
            return YeeTypeFamilyEnum.YeeType2E;
        }

        public override void SetRule(RuleSettings ruleSettings)
        {
            this.rset = ruleSettings;
            // this.rset = this.transform.GetComponent<YeeTypeFamilyEnum>();
            this.ruleCircleCollider2D.radius = this.rset.forceEffectiveRadius; //BUG 
            this.forceStrength = this.rset.forceStrength;
            this.expCoefficient = this.rset.expCoefficient;
            this.direction = this.rset.direction;
            Debug.Log(this.rset.direction);
        }

        /// <summary>
        /// YeeTypeInter2E之规则之邻接矩阵
        /// </summary>
        private static readonly Yee2EInterTypeEnum[,] yeeType2ERuleAdjecentMatrix = new Yee2EInterTypeEnum[RowSize, ColSize]
        {
            {Yee2EInterTypeEnum.Me, Yee2EInterTypeEnum.You},
            {Yee2EInterTypeEnum.You, Yee2EInterTypeEnum.Me},
        };

        public Yee2EInterTypeEnum GetInterRule(Yee2ETypeEnum thisYee2ETypeEnum, Yee2ETypeEnum thatYee2ETypeEnum)
        {
            Yee2EInterTypeEnum yee2EInterTypeEnum = yeeType2ERuleAdjecentMatrix[(int) thisYee2ETypeEnum, (int) thatYee2ETypeEnum];
            return yee2EInterTypeEnum;
        }


        protected void ApplyBehaviorRule(Yee2EInterTypeEnum yee2EInterTypeEnum, Rigidbody2D rb1, Vector2 pos1,
            Rigidbody2D rb2,
            Vector2 pos2
        )
        {
            Vector2 vector_from_a1_to_a2 = (Vector2) (pos2 - pos1);
            Vector2 direction_from_a1_to_a2 = vector_from_a1_to_a2.normalized;
            float distance_from_a1_to_a2 = direction_from_a1_to_a2.magnitude;
            if (yee2EInterTypeEnum == Yee2EInterTypeEnum.Me)
            {
                rb1.AddForce(
                    forceStrength * (-(float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient), ForceMode2D.Force);
                rb2.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
            }
            else if (yee2EInterTypeEnum == Yee2EInterTypeEnum.You)
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
            this.rset = this.ruleSettings;
            this.ruleCircleCollider2D = GameObject.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            Initialize(rset);
        }

        public override void OnTriggerStay2D(Collider2D otherCollider2D)
        {
            // Rigidbody2D thisRigidbody2D = this.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            // Vector2 thisPosition2D = this.gameObject.transform.GetComponentInParent<Transform>().position;
            // Yee2ETypeEnum thisYee2ETypeEnum = this.gameObject.transform.GetComponentInParent<Agent>().yee2ETypeEnum;
            // Rigidbody2D thatRigidbody2D = otherCollider2D.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            // Vector2 thatPosition2D = otherCollider2D.gameObject.transform.GetComponentInParent<Transform>().position;
            // Yee2ETypeEnum thatYee2ETypeEnum = otherCollider2D.gameObject.transform.GetComponentInParent<Agent>().yee2ETypeEnum;
            // this._yee2EInterTypeEnum = GetInterRule(thisYee2ETypeEnum, thatYee2ETypeEnum);
            // ApplyBehaviorRule(this._yee2EInterTypeEnum, thisRigidbody2D, thisPosition2D, thatRigidbody2D, thatPosition2D);
        }
    }
}