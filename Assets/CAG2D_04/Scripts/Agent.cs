using System;
using UnityEngine;

namespace CAG2D_04.Scripts
{
    public class Agent : MonoBehaviour
    {
        [HideInInspector] public Vector2 lastVelocity;

        public AgentSettings set;
        public string agentName;

        private YeeType2Y yeeType2Y;

        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rigidbody2D;
        private PointEffector2D pointEffector;
        private CircleCollider2D colliderCircleCollider2D;
        private CircleCollider2D effectorCircleCollider2D;
        private PhysicsMaterial2D physicsMaterial2D;

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
            physicsMaterial2D = new PhysicsMaterial2D(); // 自行新建2D物理材质
            // physicsMaterial2D =
            //     Resources.Load("Materials/Agent Physics Material 2D.physicsMaterial2D") as PhysicsMaterial2D; // 加载现有2D物理材质
            if (physicsMaterial2D != null)
            {
                physicsMaterial2D.friction = set.physicsMaterialFriction;
                physicsMaterial2D.bounciness = set.physicsMaterialBounciness;
                Debug.Log("正确设置Agent Physics Material 2D.physicsMaterial2D");
            }
            else
            {
                Debug.Log("没有正确设置Agent Physics Material 2D.physicsMaterial2D");
            }

            rigidbody2D.sharedMaterial = physicsMaterial2D;
            colliderCircleCollider2D.sharedMaterial = physicsMaterial2D;
            effectorCircleCollider2D.sharedMaterial = physicsMaterial2D;
        }

        public void SetAgent(AgentSettings agentSettings)
        {
            set = agentSettings;
            SetVelocity(set.velocity, set.speed);
            spriteRenderer.color = set.color;
            rigidbody2D.mass = set.mass;
            rigidbody2D.velocity = set.velocity * set.speed;
            rigidbody2D.drag = set.linearDrag;
            rigidbody2D.angularDrag = set.angleDrag;
            colliderCircleCollider2D.radius = set.collisionRadius;
            effectorCircleCollider2D.radius = set.magnitudeForceRadius;
            pointEffector.forceMagnitude = set.magnitudeForce;
        }


        // private void OnTriggerStay2D(Collider2D other)
        // {
        //     throw new NotImplementedException();
        // }


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
        }

        private void FixedUpdate()
        {
            this.transform.Translate(Vector2.zero * (Time.deltaTime));
        }
    }
}