using System;
using Cinemachine;
using UnityEngine;

namespace CAG2D_04.Scripts
{
    public class Agent : MonoBehaviour
    {
        [HideInInspector] public Vector2 lastVelocity;

        public AgentSettings agentSet;
        public RuleSettings ruleSet;
        public string agentName;
        [HideInInspector] public YeeType2E yeeType2E;


        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rigidbody2D;
        private PointEffector2D pointEffector;
        private CircleCollider2D colliderCircleCollider2D;
        private CircleCollider2D effectorCircleCollider2D;
        private CircleCollider2D ruleCircleCollider2D;
        private PhysicsMaterial2D physicsMaterial2D;

        private RuleYeeType2E ruleYeeType2E;

        // private Rules rules;
        private float maxSpeed;

        public void SetPosition(Vector2 pos)
        {
            transform.position = pos;
        }


        public void SetVelocity(Vector2 vel, float spe)
        {
            rigidbody2D.velocity = vel * spe;
        }

        public void SetVelocity(Vector2 vel)
        {
            rigidbody2D.velocity = vel;
        }

        public void SetColor(Color col)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = col;
            }
        }


        public void Initialize(AgentSettings agentSettings, RuleSettings ruleSettings)
        {
            this.SetAgent(agentSettings);
            ruleYeeType2E = this.gameObject.transform.Find("AgentRuleEffector").GetComponent<RuleYeeType2E>();
            ruleYeeType2E.SetRule(ruleSettings);
        }

        public void SetAgent(AgentSettings agentSettings)
        {
            this.agentSet = agentSettings;
            yeeType2E = agentSet.yeeType2E;
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            colliderCircleCollider2D = this.gameObject.transform.Find("AgentCollider").GetComponent<CircleCollider2D>();
            effectorCircleCollider2D = this.gameObject.transform.Find("AgentEffector").GetComponent<CircleCollider2D>();
            ruleCircleCollider2D = this.gameObject.transform.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            pointEffector = this.gameObject.transform.Find("AgentEffector").GetComponent<PointEffector2D>();
            name = agentSet.agentName;
            SetPosition(agentSet.position);
            SetVelocity(agentSet.velocity, agentSet.speed);
            SetColor(agentSet.color);
            rigidbody2D.mass = agentSet.mass;
            colliderCircleCollider2D.radius = agentSet.collisionRadius;
            effectorCircleCollider2D.radius = agentSet.magnitudeForceRadius;
            pointEffector.forceMagnitude = agentSet.magnitudeForce;
            maxSpeed = agentSet.maxSpeed;

            // 设置2D物理材质。
            physicsMaterial2D = new PhysicsMaterial2D(); // 自行新建2D物理材质
            // physicsMaterial2D =
            //     Resources.Load("Materials/Agent Physics Material 2D.physicsMaterial2D") as PhysicsMaterial2D; // 加载现有2D物理材质
            if (physicsMaterial2D != null)
            {
                physicsMaterial2D.friction = agentSet.physicsMaterialFriction;
                physicsMaterial2D.bounciness = agentSet.physicsMaterialBounciness;
                // Debug.Log("正确设置Agent Physics Material 2D.physicsMaterial2D");
            }

            // else
            // {
            // Debug.Log("没有正确设置Agent Physics Material 2D.physicsMaterial2D");
            // }
            rigidbody2D.sharedMaterial = physicsMaterial2D;
            colliderCircleCollider2D.sharedMaterial = physicsMaterial2D;
            effectorCircleCollider2D.sharedMaterial = physicsMaterial2D;
            ruleCircleCollider2D.sharedMaterial = physicsMaterial2D;
        }

        void Awake()
        {
            Initialize(agentSet, ruleSet);
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void FixedUpdate()
        {
            this.transform.Translate(Vector2.zero * (Time.deltaTime));
            rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxSpeed);
        }
    }
}