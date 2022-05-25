using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

namespace CAG2D_04.Scripts
{
    public class RuleYeeType2E : MonoBehaviour
    {
        private RuleSettings ruleSettings;
        private float forceStrength = 0f;
        private YeeType2E yeeType2E;

        // private Agent a1;
        // private Agent a2;
        private float pownum = 2f;
        private CircleCollider2D ruleCircleCollider2D;

        Rigidbody2D rb1;
        Rigidbody2D rb2;
        Transform tf1;
        Transform tf2;


        private void GetObject(Agent a1, Agent a2)
        {
        }

        public void Initialize(RuleSettings ruleSettings)
        {
            // this.ruleSettings = ruleSettings;
            SetRule(ruleSettings);
        }

        public void SetRule(RuleSettings ruleSettings)
        {
            // this.ruleSettings = ruleSettings;
            ruleCircleCollider2D = GameObject.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            ruleCircleCollider2D.radius = ruleSettings.forceEffectiveRadius;
            this.forceStrength = ruleSettings.forceStrength;
            this.pownum = ruleSettings.pownum;
        }


        // private void YeeType2ERule(Agent a1, Agent a2)
        // {
        //     // Rigidbody2D rb1;
        //     // Rigidbody2D rb2;
        //     // Transform tf1;
        //     // Transform tf2;
        //     rb1 = a1.gameObject.GetComponent<Rigidbody2D>();
        //     // tf1 = a1.gameObject.transform;
        //
        //     rb2 = a2.gameObject.GetComponent<Rigidbody2D>();
        //     // tf2 = a2.gameObject.transform;
        //     Vector2 vector_from_a1_to_a2 = (Vector2) (a1.transform.position - a2.transform.position);
        //     Vector2 direction_from_a1_to_a2 = vector_from_a1_to_a2.normalized;
        //     float distance_from_a1_to_a2 = direction_from_a1_to_a2.magnitude;
        //     if (a1.agentSettings.yeeType2E == a2.agentSettings.yeeType2E)
        //     {
        //         rb1.AddForce(-direction_from_a1_to_a2 / math.pow(distance_from_a1_to_a2, pownum), ForceMode2D.Force);
        //         rb2.AddForce(direction_from_a1_to_a2 / math.pow(distance_from_a1_to_a2, pownum), ForceMode2D.Force);
        //     }
        //     else
        //     {
        //         rb1.AddForce(direction_from_a1_to_a2 / math.pow(distance_from_a1_to_a2, pownum), ForceMode2D.Force);
        //         rb2.AddForce(-direction_from_a1_to_a2 / math.pow(distance_from_a1_to_a2, pownum), ForceMode2D.Force);
        //     }
        // }

        private void YeeType2ERule(Rigidbody2D rb1, Vector2 pos1, YeeType2E t1, Rigidbody2D rb2, Vector2 pos2,
            YeeType2E t2)
        {
            Vector2 vector_from_a1_to_a2 = (Vector2) (pos2 - pos1);
            Vector2 direction_from_a1_to_a2 = vector_from_a1_to_a2.normalized;
            float distance_from_a1_to_a2 = direction_from_a1_to_a2.magnitude;
            if (t1 == t2)
            {
                rb1.AddForce(forceStrength * (direction_from_a1_to_a2) / math.pow(distance_from_a1_to_a2, pownum),
                    ForceMode2D.Force);
                rb2.AddForce(forceStrength * (-direction_from_a1_to_a2) / math.pow(distance_from_a1_to_a2, pownum),
                    ForceMode2D.Force);
            }
            else
            {
                rb1.AddForce(forceStrength * (-direction_from_a1_to_a2) / math.pow(distance_from_a1_to_a2, pownum),
                    ForceMode2D.Force);
                rb2.AddForce(forceStrength * (direction_from_a1_to_a2) / math.pow(distance_from_a1_to_a2, pownum),
                    ForceMode2D.Force);
            }
        }


        private void Awake()
        {
            // rb1 = a1.gameObject.GetComponent<Rigidbody2D>();
            // tf1 = a1.gameObject.transform;
            //
            // rb2 = a2.gameObject.GetComponent<Rigidbody2D>();
            // tf2 = a2.gameObject.transform;
            Initialize(ruleSettings);
        }

        private void OnTriggerStay2D(Collider2D otherCollider2D)
        {
            // Agent thisAgent = transform.parent.GetComponent<Agent>();
            // Agent otherAgent = otherCollider2D.gameObject.GetComponentInParent<Agent>();
            // YeeType2ERule(thisAgent, otherAgent);
            Rigidbody2D thisRigidbody2D = this.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 thisPosition2D = this.gameObject.transform.GetComponentInParent<Transform>().position;
            YeeType2E thisYeeType2E = this.gameObject.transform.GetComponentInParent<Agent>().yeeType2E;
            Rigidbody2D otherRigidbody2D = otherCollider2D.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            Vector2 otherPosition2D = otherCollider2D.gameObject.transform.GetComponentInParent<Transform>().position;
            YeeType2E otherYeeType2E = otherCollider2D.gameObject.transform.GetComponentInParent<Agent>().yeeType2E;
            YeeType2ERule(thisRigidbody2D, thisPosition2D, thisYeeType2E, otherRigidbody2D, otherPosition2D,
                otherYeeType2E);
        }
    }
}