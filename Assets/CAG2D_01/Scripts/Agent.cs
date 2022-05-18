using UnityEngine;

namespace CAG2D_01.Scripts
{
    public class Agent : MonoBehaviour
    {
        [HideInInspector] public Vector2 lastVelocity;

        public AgentSettings set;
        public string agentName;

        // public Color color = Color.white;
        // public float mass = 1f;
        // public float size = 10f;
        // public float collisionRadius = 0.5f;
        // public Vector2 position;
        // public Vector2 velocity = new Vector2(0, 0);
        // public float speed = 30f;
        // public float magnitudeForce = -10f;
        // public float magnitudeForceRadius = 5f;


        // [SerializeField] public float ForceMagnitude
        // {
        //     get => pointEffector.forceMagnitude;
        //     set => pointEffector.forceMagnitude = value;
        // }
        //
        //
        // public float MagnitudeForceRadius
        // {
        //     get => colliderCircleCollider2D.radius;
        //     set => colliderCircleCollider2D.radius = value;
        // }

        // public Agent(float mass, Vector2 position, float speed, float magnitudeForce, float magnitudeForceRadius,
        //     float size)
        // {
        //     this.mass = mass;
        //     this.position = position;
        //     this.speed = speed;
        //     this.magnitudeForce = magnitudeForce;
        //     this.magnitudeForceRadius = magnitudeForceRadius;
        //     this.size = size;
        // }

        // private Transform target;
        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rigidbody2D;
        private PointEffector2D pointEffector;
        private CircleCollider2D colliderCircleCollider2D;
        private CircleCollider2D effectorCircleCollider2D;

        public void SetPosition(Vector2 pos)
        {
            transform.position = pos;
        }


        public void SetVelocity(Vector2 vel, float spe)
        {
            rigidbody2D.velocity = vel * spe;
        }

        public void SetColor(Color col)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = col;
            }
        }

        public void Initialize(AgentSettings agentSettings)
        {
            this.set = agentSettings;
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            pointEffector = GetComponentInChildren<PointEffector2D>();
            colliderCircleCollider2D = GameObject.Find("AgentCollider").GetComponent<CircleCollider2D>();
            effectorCircleCollider2D = GameObject.Find("AgentEffector").GetComponent<CircleCollider2D>();
            name = set.agentName;
            SetPosition(set.position);
            SetVelocity(set.velocity, set.speed);
            SetColor(set.color);
            rigidbody2D.mass = set.mass;
            colliderCircleCollider2D.radius = set.collisionRadius;
            effectorCircleCollider2D.radius = set.magnitudeForceRadius;
            pointEffector.forceMagnitude = set.magnitudeForce;
        }

        public void SetAgent(AgentSettings agentSettings)
        {
            set = agentSettings;
            SetVelocity(set.velocity, set.speed);
            spriteRenderer.color = set.color;
            rigidbody2D.mass = set.mass;
            rigidbody2D.velocity = set.velocity * set.speed;
            colliderCircleCollider2D.radius = set.collisionRadius;
            effectorCircleCollider2D.radius = set.magnitudeForceRadius;
            pointEffector.forceMagnitude = set.magnitudeForce;
        }

        void Awake()
        {
            Initialize(set);
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            // SetAgent(set);
            // transform.Translate(Vector2.zero * Time.deltaTime * gameSettings.spe);
        }

        private void FixedUpdate()
        {
            this.transform.Translate(Vector2.zero * (Time.deltaTime));
        }
    }
}