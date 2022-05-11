using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ComplexAgentsGame2D
{
    public class Agent : MonoBehaviour
    {
        public AgentSettings settings;

        public Vector2 position;
        public Vector2 forward;

        public float radiusSize = 1f;

        private SpriteRenderer spriteRenderer;
        private Transform target;

        public void SetColor(Color color)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = color;
            }
        }

        public void Initialize(AgentSettings settings, Transform target)
        {
            this.target = target;
            this.settings = settings;
            this.transform.position = this.position;
        }

        void Awake()
        {
            spriteRenderer = transform.GetComponent<SpriteRenderer>();
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
            // throw new NotImplementedException();
        }
    }
}