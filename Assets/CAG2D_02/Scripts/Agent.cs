using UnityEngine;

namespace CAG2D_02.Scripts
{
    public class Agent : MonoBehaviour
    {
        [HideInInspector] public Vector2 lastVelocity;

        public float mass = 1f;
        public float energy = 1f;
        public Vector2 position = new Vector2(0f, 0f);
        public float speed = 10f;
        public Vector2 acceleration = new Vector2(0f, 0f);
        public Vector2 momentum = new Vector2(0f, 0f);
        public Color color = Color.white;
        public float size = 10f;
        public bool isVisual;

        public SpriteRenderer spriteRenderer;

        public Rigidbody2D rigidbody2D;

        // private Transform target;

        public void SetPosition(Vector2 pos)
        {
            transform.position = pos;
        }

        public void SetVelocity(Vector2 vel, float spe)
        {
            rigidbody2D.velocity = vel * spe;
            Debug.Log("self's vel is " + transform.forward.ToString());
        }

        public void SetColor(Color col)
        {
            if (spriteRenderer != null)
            {
                color = col;
                spriteRenderer.color = color;
                Debug.Log("agent " + this.name + " 's color is " + spriteRenderer.color);
            }
        }

        // public void Initialize(AgentSettings agentSettings)
        public void Initialize()
        {
            rigidbody2D = GetComponentInChildren<Rigidbody2D>();
            spriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
            Debug.Log("component name is " + spriteRenderer.name);
            rigidbody2D.velocity = new Vector2(0, 0) * speed;
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
            transform.Translate(Vector2.zero * Time.deltaTime * speed);
        }
    }
}