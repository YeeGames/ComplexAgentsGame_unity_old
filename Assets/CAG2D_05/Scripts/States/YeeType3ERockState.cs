using System;
using UnityEngine;
using CAG2D_05.Scripts.YeeTypes;

namespace CAG2D_05.Scripts.States
{
    public class YeeType3ERockState : YeeType3EState<Agent>
    {
        [HideInInspector] public Rigidbody2D thisRigidbody2D;
        [HideInInspector] public Vector2 thisPosition2D;
        [HideInInspector] public YeeType3E thisYeeType3E;
        [HideInInspector] public Agent agent;
        [HideInInspector] public Agent other;

        [HideInInspector] public YeeType3ERule yeeType3ERule;

        KeState keState = new KeState();
        BeKeState beKeState = new BeKeState();

        private void Start()
        {
            // thisRigidbody2D = this.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            // thisPosition2D = this.gameObject.transform.GetComponentInParent<Transform>().position;
            // thisYeeType3E = this.gameObject.transform.GetComponentInParent<Agent>().yeeType3E;
            thisRigidbody2D = agent.gameObject.transform.GetComponent<Rigidbody2D>();
            thisPosition2D = (Vector2) agent.gameObject.transform.GetComponent<Transform>().position;
            thisYeeType3E = agent.gameObject.transform.GetComponent<Agent>().yeeType3E;
        }


        public override void Enter(Agent a)
        {
            throw new System.NotImplementedException();
        }

        // public override void Execute(Agent agent)
        public override void Execute(Agent a)
        {
            
            // throw new System.NotImplementedException();
            foreach (var yeeType3E in this.yeeType3Es)
            {
                
                // TODO 遍历添加联合状态
                keState.Execute(this.agent, a);
            }
        }

        public override void Exit(Agent a)
        {
            throw new System.NotImplementedException();
        }

        public override void OnTriggerStay(Collider2D otherCollider2D)
        {
            // Rigidbody2D otherRigidbody2D = otherCollider2D.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            // Vector2 otherPosition2D = (Vector2) otherCollider2D.gameObject.transform.GetComponentInParent<Transform>().position;
            // YeeType3E otherYeeType3E = otherCollider2D.gameObject.transform.GetComponentInParent<Agent>().yeeType3E;
            // Execute(thisRigidbody2D, thisPosition2D, thisYeeType3E, otherRigidbody2D, otherPosition2D, otherYeeType3E);
            this.other.rigidbody2D = otherCollider2D.gameObject.transform.GetComponentInParent<Rigidbody2D>();
            this.other.transform.position = (Vector2) otherCollider2D.gameObject.transform.GetComponentInParent<Transform>().position;
            this.other.yeeType3E = otherCollider2D.gameObject.transform.GetComponentInParent<Agent>().yeeType3E;
            Execute(this.other);
        }
    }
}