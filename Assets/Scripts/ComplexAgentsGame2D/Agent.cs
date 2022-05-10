using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ComplexAgentsGame2D
{
    public class Agent : MonoBehaviour
    {
        public AgentSettings agentSettings;

        public Vector2 position;

        public float size;

        private Material material;

        public void setColor(Color color)
        {
            if (material != null)
            {
                material.color = color;
            }
        }

        void Awake()
        {
            material = transform.GetComponentInChildren<MeshRenderer>().material;
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
            throw new NotImplementedException();
        }
    }
}