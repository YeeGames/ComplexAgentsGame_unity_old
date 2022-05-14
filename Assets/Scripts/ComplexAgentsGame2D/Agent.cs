using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;

namespace ComplexAgentsGame2D
{
    public class Agent : MonoBehaviour
    {
        public AgentSettings set;
        public Team team;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 lastVelocity;
        public float speed = 1f;
        public Vector2 forward;

        public float radius = 10f;

        private SpriteRenderer spriteRenderer;
        // private Transform target;

        public void SetPosition(Vector2 pos)
        {
            transform.position = pos;
        }

        public void SetColor(Color color)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = color;
            }
        }

        public void Initialize(AgentSettings settings, Transform target)
        {
            // this.target = target;
            this.set = settings;
            this.transform.position = this.position;
        }

        void Awake()
        {
            spriteRenderer = transform.GetComponent<SpriteRenderer>();
            velocity = new Vector2(0, 0) * speed;
            Debug.Log("self's velocity is " + velocity.ToString());
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            // transform.Translate(Vector2.zero * Time.deltaTime * set.speed);
        }

        void LateUpdate()
        {
            lastVelocity = velocity;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "Wall")
            {
                Debug.Log("碰撞到墙体");
                Vector2 reflaexAngle = Vector2.Reflect(lastVelocity, other.GetContact(0).normal);
                velocity = reflaexAngle.normalized * lastVelocity.magnitude;
            }
        }

        // TODO HACK 构建失败
        // private void OnTriggerEnter2D(Collider2D other)
        // {
        //     if (other.gameObject.name == "Wall")
        //     {
        //         Debug.Log("触发到墙体");
        //         Vector2 contactPoint = other.bounds.ClosestPoint((Vector2) transform.position);
        //         Vector2 reflaexAngle = Vector2.Reflect(lastVelocity, contactPoint.normal???);
        //         velocity = reflaexAngle.normalized * lastVelocity.magnitude;
        //     }
        // }

        private void FixedUpdate()
        {
            transform.Translate(Vector2.zero * Time.deltaTime * set.speed);
        }
    }
}