using UnityEngine;

namespace CAG2D_01.Scripts
{
    public class Agent : MonoBehaviour
    {
        [HideInInspector] public Vector2 lastVelocity;

        public Color color = Color.white;
        public float mass = 1f;
        public Vector2 position;
        public Vector2 velocity = new Vector2(0, 0);
        public float speed = 30f;
        public float magnitudeForce = 10f;
        public float magnitudeForceRadius = 5f;


        private float ForceMagnitude
        {
            get => pointEffector.forceMagnitude;
            set => pointEffector.forceMagnitude = magnitudeForce;
        }


        private float MagnitudeForceRadius
        {
            get => circleCollider2D.radius;
            set => circleCollider2D.radius = magnitudeForceRadius;
        }


        // private Transform target;
        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rigidbody2D;
        private PointEffector2D pointEffector;
        private CircleCollider2D circleCollider2D;
        private float energy = 1f;
        private float size = 10f;
        private Vector2 acceleration;
        private Vector2 momentum;

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
                color = col;
                spriteRenderer.color = color;
            }
        }

        public void Initialize()
        {
            transform.position = position;
            pointEffector = GetComponentInChildren<PointEffector2D>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            circleCollider2D = GetComponentInChildren<CircleCollider2D>();
            spriteRenderer.color = color;
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.mass = mass;
            rigidbody2D.velocity = velocity * speed;
        }

        void Awake()
        {
            Initialize();
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            // transform.Translate(Vector2.zero * Time.deltaTime * gameSettings.spe);
        }

        private void FixedUpdate()
        {
            this.transform.Translate(Vector2.zero * (Time.deltaTime * speed));
        }
    }
}