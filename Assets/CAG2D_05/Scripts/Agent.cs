using CAG2D_05.Scripts.Settings;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class Agent : MonoBehaviour
    {
        [HideInInspector] public ScriptableObject agentSettingsScriptableObject;
        [HideInInspector] public ScriptableObject ruleSettingsScriptableObject;

        public AgentSettings agentSettings;

        public RuleSettings ruleSettings;

        [HideInInspector] public AgentSettings aset;
        [HideInInspector] public RuleSettings rset;

        [HideInInspector] public Yee.YeeTypes.YeeTypeFamily yeeTypeFamily;
        [HideInInspector] public YeeType2E yeeType2E;
        [HideInInspector] public YeeType3E yeeType3E;

        [HideInInspector] public YeeTypeInter3E yeeTypeInter3E;
        [HideInInspector] public YeeRule yeeRule;


        [HideInInspector] public SpriteRenderer spriteRenderer;
        [HideInInspector] public new Rigidbody2D rigidbody2D;
        [HideInInspector] public PointEffector2D pointEffector;
        [HideInInspector] public CircleCollider2D colliderCircleCollider2D;
        [HideInInspector] public CircleCollider2D effectorCircleCollider2D;
        [HideInInspector] public CircleCollider2D ruleCircleCollider2D;
        [HideInInspector] public PhysicsMaterial2D physicsMaterial2D;

        [HideInInspector] public Yee2ERule yee2ERule;
        [HideInInspector] public Yee2ERule yeeType3ERule;

        [HideInInspector] public float maxSpeed;
        [HideInInspector] public float maxAngularSpeed;

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
            this.SetAgentSettings(agentSettings);
            if (yeeTypeFamily == Yee.YeeTypes.YeeTypeFamily.YeeType2E)
            {
                yee2ERule.SetRule(ruleSettings);
            }
            else if (yeeTypeFamily == Yee.YeeTypes.YeeTypeFamily.YeeType3E)
            {
                yeeType3ERule.SetRule(ruleSettings);
            }
        }

        public void SetAgentSettings(AgentSettings agentSettings)
        {
            this.aset = agentSettings;
            if (yeeTypeFamily == Yee.YeeTypes.YeeTypeFamily.YeeType2E)
            {
            }

            this.yeeType2E = this.aset.yeeType2E;
            this.yeeType3E = this.aset.yeeType3E;
            this.name = this.aset.agentName;
            this.SetColor(this.aset.color);
            this.SetPosition(this.aset.position);
            this.SetVelocity(this.aset.velocity, this.aset.initSpeed);
            this.colliderCircleCollider2D.radius = this.aset.collisionRadius;
            this.effectorCircleCollider2D.radius = this.aset.magnitudeForceRadius;
            this.pointEffector.forceMagnitude = this.aset.magnitudeForce;
            this.maxSpeed = this.aset.maxSpeed;
            this.maxAngularSpeed = this.aset.maxAngularSpeed;
            this.rigidbody2D.mass = this.aset.mass;
            this.rigidbody2D.drag = this.aset.linearDrag;
            this.rigidbody2D.angularDrag = this.aset.angularDrag;


            // 设置2D物理材质。
            this.physicsMaterial2D = new PhysicsMaterial2D(); // 自行新建2D物理材质
            if (this.physicsMaterial2D != null)
            {
                this.physicsMaterial2D.friction = this.aset.physicsMaterialFriction;
                this.physicsMaterial2D.bounciness = this.aset.physicsMaterialBounciness;
            }

            this.rigidbody2D.sharedMaterial = this.physicsMaterial2D;
            this.colliderCircleCollider2D.sharedMaterial = this.physicsMaterial2D;
            this.effectorCircleCollider2D.sharedMaterial = this.physicsMaterial2D;
            this.ruleCircleCollider2D.sharedMaterial = this.physicsMaterial2D;
        }


        void Awake()
        {
            this.aset = this.agentSettings;
            this.rset = this.ruleSettings;

            this.rigidbody2D = GetComponent<Rigidbody2D>();
            this.spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            this.colliderCircleCollider2D =
                this.gameObject.transform.Find("AgentCollider").GetComponent<CircleCollider2D>();
            this.effectorCircleCollider2D =
                this.gameObject.transform.Find("AgentEffector").GetComponent<CircleCollider2D>();
            this.ruleCircleCollider2D =
                this.gameObject.transform.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            this.pointEffector = this.gameObject.transform.Find("AgentEffector").GetComponent<PointEffector2D>();
            this.yeeRule = this.gameObject.transform.Find("AgentRuleEffector").GetComponent<YeeRule>();

            Initialize(this.aset, this.rset);
        }

        // Start is called before the first frame update
        void Start()
        {
            // Initialize(this.agentSettings,this.ruleSettings);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void FixedUpdate()
        {
            this.transform.Translate(Vector2.zero * (Time.deltaTime));
            this.rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxSpeed); // 限制最大速度；
            this.rigidbody2D.angularVelocity = Mathf.Max(rigidbody2D.angularVelocity, maxAngularSpeed); // 限制最大角速度；
        }
    }
}