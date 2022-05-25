using System;
using Cinemachine;
using UnityEngine;

namespace CAG2D_04.Scripts
{
    public class Agent : MonoBehaviour
    {
        [HideInInspector] public Vector2 lastVelocity;

        public AgentSettings agentSettings;
        public RuleSettings ruleSettings;
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
            // agentSettings = agentSettings;
            yeeType2E = agentSettings.yeeType2E;
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            colliderCircleCollider2D = this.gameObject.transform.Find("AgentCollider").GetComponent<CircleCollider2D>();
            effectorCircleCollider2D = this.gameObject.transform.Find("AgentEffector").GetComponent<CircleCollider2D>();
            ruleCircleCollider2D = this.gameObject.transform.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            pointEffector = this.gameObject.transform.Find("AgentEffector").GetComponent<PointEffector2D>();
            name = agentSettings.agentName;
            SetPosition(agentSettings.position);
            SetVelocity(agentSettings.velocity, agentSettings.speed);
            SetColor(agentSettings.color);
            rigidbody2D.mass = agentSettings.mass;
            colliderCircleCollider2D.radius = agentSettings.collisionRadius;
            effectorCircleCollider2D.radius = agentSettings.magnitudeForceRadius;
            pointEffector.forceMagnitude = agentSettings.magnitudeForce;
            maxSpeed = agentSettings.maxSpeed;

            // 设置2D物理材质。
            physicsMaterial2D = new PhysicsMaterial2D(); // 自行新建2D物理材质
            if (physicsMaterial2D != null)
            {
                physicsMaterial2D.friction = agentSettings.physicsMaterialFriction;
                physicsMaterial2D.bounciness = agentSettings.physicsMaterialBounciness;
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
            Initialize(agentSettings, ruleSettings);
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