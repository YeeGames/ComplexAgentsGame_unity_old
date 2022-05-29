using Unity.Mathematics;
using UnityEngine;


namespace CAG2D_05.Scripts
{
    public class RuleYeeType3E : MonoBehaviour
    {
        private RuleSettings ruleSettings;
        private RuleSettings rset;
        private YeeType3E yeeType3E;

        private float forceStrength = 0f;

        // private YeeType3E yeeType3E;
        private int direction = 1;
        private RuleYeeType3E ruleYeeType3E;
        private float expCoefficient = 2f;
        private CircleCollider2D ruleCircleCollider2D;

        private Rigidbody2D rb1;
        private Rigidbody2D rb2;
        private Transform tf1;
        private Transform tf2;


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
            // this.rset = this.transform.GetComponent<Rules>();
            this.ruleCircleCollider2D.radius = this.rset.forceEffectiveRadius;
            this.forceStrength = this.rset.forceStrength;
            this.expCoefficient = this.rset.expCoefficient;
            this.direction = this.rset.direction;
            Debug.Log(this.rset.direction);
        }


        public void SetRule()
        {
        }

        private void YeeType3ERule(Rigidbody2D rb1, Vector2 pos1, YeeType3E t1, Rigidbody2D rb2, Vector2 pos2,
            YeeType3E t2)
        {
            Vector2 vector_from_a1_to_a2 = (Vector2) (pos2 - pos1);
            Vector2 direction_from_a1_to_a2 = vector_from_a1_to_a2.normalized;
            float distance_from_a1_to_a2 = direction_from_a1_to_a2.magnitude;

            if (t1 == YeeType3E.Rock && t2 == YeeType3E.Scissors)
            {
                rb1.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient), ForceMode2D.Force);
                rb2.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
            }
            else if (t1 == YeeType3E.Scissors && t2 == YeeType3E.Cloth)
            {
                rb1.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
                rb2.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
                    math.pow(distance_from_a1_to_a2, expCoefficient),
                    ForceMode2D.Force);
            }
            else if (t1 == YeeType3E.Cloth && t2 == YeeType3E.Rock)
            {
                rb1.AddForce(
                    forceStrength * ((float) direction * direction_from_a1_to_a2) /
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

        private void OnTriggerStay2D(Collider2D otherCollider2D)
        {
            Rigidbody2D thisRigidbody2D = this.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 thisPosition2D = this.gameObject.transform.GetComponentInParent<Transform>().position;
            YeeType3E thisYeeType3E = this.gameObject.transform.GetComponentInParent<Agent>().yeeType3E;
            Rigidbody2D otherRigidbody2D = otherCollider2D.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 otherPosition2D = otherCollider2D.gameObject.transform.GetComponentInParent<Transform>().position;
            YeeType3E otherYeeType3E = otherCollider2D.gameObject.transform.GetComponentInParent<Agent>().yeeType3E;
            YeeType3ERule(thisRigidbody2D, thisPosition2D, thisYeeType3E, otherRigidbody2D, otherPosition2D,
                otherYeeType3E);
        }
    }
}