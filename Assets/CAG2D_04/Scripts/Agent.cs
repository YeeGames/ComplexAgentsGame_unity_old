using UnityEngine;
using UnityEditor;

namespace CAG2D_04.Scripts
{
    public class Agent : MonoBehaviour
    {
        [HideInInspector] public ScriptableObject agentSettingsScriptableObject;
        [HideInInspector] public ScriptableObject ruleSettingsScriptableObject;

        public AgentSettings agentSettings;

        public RuleSettings ruleSettings;
        // public ScriptableObject ruleSettings =
        //     AssetDatabase.LoadAssetAtPath<RuleSettings>(@"Assets/CAG2D_04/Settings/Rule Settings.asset");

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
        private float maxAngularSpeed;


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
            ruleYeeType2E.SetRule(ruleSettings);
        }

        public void SetAgent(AgentSettings agentSettings)
        {
            this.agentSettings = agentSettings;
            // this.agentSettings = GameObject.Find("Settings/Agent Settings");
            // yeeType2E = this.agentSettings.yeeType2E;
            // rigidbody2D = GetComponent<Rigidbody2D>();
            // spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            // colliderCircleCollider2D = this.gameObject.transform.Find("AgentCollider").GetComponent<CircleCollider2D>();
            // effectorCircleCollider2D = this.gameObject.transform.Find("AgentEffector").GetComponent<CircleCollider2D>();
            // ruleCircleCollider2D = this.gameObject.transform.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            // pointEffector = this.gameObject.transform.Find("AgentEffector").GetComponent<PointEffector2D>();
            this.agentName = this.agentSettings.agentName;
            this.SetColor(this.agentSettings.color);
            this.SetPosition(this.agentSettings.position);
            this.SetVelocity(this.agentSettings.velocity, this.agentSettings.speed);
            this.colliderCircleCollider2D.radius = this.agentSettings.collisionRadius;
            this.effectorCircleCollider2D.radius = this.agentSettings.magnitudeForceRadius;
            this.pointEffector.forceMagnitude = this.agentSettings.magnitudeForce;
            this.maxSpeed = this.agentSettings.maxSpeed;
            this.maxAngularSpeed = this.agentSettings.maxAngularSpeed;
            this.rigidbody2D.mass = this.agentSettings.mass;
            this.rigidbody2D.drag = this.agentSettings.linearDrag;
            this.rigidbody2D.angularDrag = this.agentSettings.angularDrag;


            // 设置2D物理材质。
            this.physicsMaterial2D = new PhysicsMaterial2D(); // 自行新建2D物理材质
            if (this.physicsMaterial2D != null)
            {
                this.physicsMaterial2D.friction = this.agentSettings.physicsMaterialFriction;
                this.physicsMaterial2D.bounciness = this.agentSettings.physicsMaterialBounciness;
                // Debug.Log("正确设置Agent Physics Material 2D.physicsMaterial2D");
            }

            // else
            // {                                                 
            // Debug.Log("没有正确设置Agent Physics Material 2D.physicsMaterial2D");
            // }
            this.rigidbody2D.sharedMaterial = this.physicsMaterial2D;
            this.colliderCircleCollider2D.sharedMaterial = this.physicsMaterial2D;
            this.effectorCircleCollider2D.sharedMaterial = this.physicsMaterial2D;
            this.ruleCircleCollider2D.sharedMaterial = this.physicsMaterial2D;
        }

        void Awake()
        {
            this.yeeType2E = this.agentSettings.yeeType2E;
            this.rigidbody2D = GetComponent<Rigidbody2D>();
            this.spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            this.colliderCircleCollider2D =
                this.gameObject.transform.Find("AgentCollider").GetComponent<CircleCollider2D>();
            this.effectorCircleCollider2D =
                this.gameObject.transform.Find("AgentEffector").GetComponent<CircleCollider2D>();
            this.ruleCircleCollider2D =
                this.gameObject.transform.Find("AgentRuleEffector").GetComponent<CircleCollider2D>();
            this.pointEffector = this.gameObject.transform.Find("AgentEffector").GetComponent<PointEffector2D>();
            this.ruleYeeType2E = this.gameObject.transform.Find("AgentRuleEffector").GetComponent<RuleYeeType2E>();

            // this.agentSettingsScriptableObject = AssetDatabase.LoadAssetAtPath<AgentSettings>("Assets/CAG2D_04/Settings/Agent Settings.asset");
            // this.agentSettingsScriptableObject

            // this.agentSettings = this.agentSettingsScriptableObject;

            Initialize(this.agentSettings, this.ruleSettings);
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