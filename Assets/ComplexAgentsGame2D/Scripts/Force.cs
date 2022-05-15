using UnityEngine;

namespace ComplexAgentsGame2D.Scripts
{
    public class Force : MonoBehaviour
    {
        // 【
        // ————————————————
        // 版权声明：本文为CSDN博主「Monkey_Xuan」的原创文章，遵循CC 4.0 BY-SA版权协议，转载请附上原文出处链接及本声明。
        // 原文链接：https://blog.csdn.net/Monkey_Xuan/article/details/121118671

        [HideInInspector] public Transform targetObject1;
        [HideInInspector] public Transform targetImage1;
        [HideInInspector] public float targetRange = 100; //大于等于0

        void Start()
        {
            SetTargetImagePositon();
        }

        public void SetTargetImagePositon()
        {
            if (Vector3.Distance(targetObject1.position, Vector3.zero) >= targetRange)
            {
                targetObject1.position = Vector3.Normalize(targetObject1.position) * targetRange;
            }

            targetImage1.localPosition = targetObject1.position;
        }
        // 】
        
        // Vector3 reflexAngle=Vector3.Reflect

        // TODO HACK 没有用到。【磁力，转载自网络，原链接忘了。

        public LayerMask m_MagneticLayers;
        public Vector3 m_Position;
        public float m_Radius;
        public float m_Force;

        void FixedUpdate()
        {
            Collider[] colliders;
            Rigidbody2D rigidbody;
            colliders = Physics.OverlapSphere(transform.position + m_Position, m_Radius, m_MagneticLayers);
            foreach (Collider collider in colliders)
            {
                rigidbody = (Rigidbody2D) collider.gameObject.GetComponent(typeof(Rigidbody));
                if (rigidbody == null)
                {
                    continue;
                }

                // rigidbody.AddRelativeForce(m_Force * -1, transform.position + m_Position, m_Radius);
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + m_Position, m_Radius);
        }

        // 】
    }
}