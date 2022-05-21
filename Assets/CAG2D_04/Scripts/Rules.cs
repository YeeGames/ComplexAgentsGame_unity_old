using Unity.Mathematics;
using UnityEngine;

namespace CAG2D_04.Scripts
{
    public class Rules : MonoBehaviour
    {
        private YeeType2Y yeeType2Y;
        private YeeTypeAR yeeTypeAR;
        
        private Agent a1;
        private Agent a2;

        Rigidbody2D rb1;
        Rigidbody2D rb2;
        Transform tf1;
        Transform tf2;

        private void GetObject(Agent a1, Agent a2)
        {
            rb1 = a1.gameObject.GetComponent<Rigidbody2D>();
            tf1 = a1.gameObject.transform;

            rb2 = a2.gameObject.GetComponent<Rigidbody2D>();
            tf2 = a2.gameObject.transform;
        }

        /// <summary>
        /// 设计规则YeeType2Y
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        public void SetYeeType2YRules(Agent a1, Agent a2)
        {
            Vector2 vector_from_a1_to_a2 = (Vector2) (a2.transform.position - a1.transform.position);
            Vector2 direction_from_a1_to_a2 = vector_from_a1_to_a2.normalized;
            float distance_from_a1_to_a2 = direction_from_a1_to_a2.magnitude;
            if (a1.set.yeeType2Y == a2.set.yeeType2Y)
            {
                rb1.AddForce(-direction_from_a1_to_a2 / math.pow(distance_from_a1_to_a2, 1), ForceMode2D.Force);
                rb2.AddForce(direction_from_a1_to_a2 / math.pow(distance_from_a1_to_a2, 1), ForceMode2D.Force);
            }
            else
            {
                rb1.AddForce(direction_from_a1_to_a2 / math.pow(distance_from_a1_to_a2, 1), ForceMode2D.Force);
                rb2.AddForce(-direction_from_a1_to_a2 / math.pow(distance_from_a1_to_a2, 1), ForceMode2D.Force);
            }
        }


        /// <summary>
        /// 设计规则YeeTypeAR：基于Attractive Force与Rejective Force。
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        public void SetYeeTypeARRules(Agent a1, Agent a2)
        {
            // Rigidbody2D rb1;
            // Rigidbody2D rb2;
            // Transform tf1;
            // Transform tf2;
            rb1 = a1.gameObject.GetComponent<Rigidbody2D>();
            tf1 = a1.gameObject.transform;

            rb2 = a2.gameObject.GetComponent<Rigidbody2D>();
            tf2 = a2.gameObject.transform;


            Vector2 vector_from_a1_to_a2 = (Vector2) (a2.transform.position - a1.transform.position);
            Vector2 direction_from_a1_to_a2 = vector_from_a1_to_a2.normalized;
            float distance_from_a1_to_a2 = direction_from_a1_to_a2.magnitude;
            if (a1.set.yeeType2Y == a2.set.yeeType2Y)
            {
                
                rb1.AddForce(-direction_from_a1_to_a2 / math.pow(distance_from_a1_to_a2, 1), ForceMode2D.Force);
                rb2.AddForce(direction_from_a1_to_a2 / math.pow(distance_from_a1_to_a2, 1), ForceMode2D.Force);
            }
            else
            {
                rb1.AddForce(direction_from_a1_to_a2 / math.pow(distance_from_a1_to_a2, 1), ForceMode2D.Force);
                rb2.AddForce(-direction_from_a1_to_a2 / math.pow(distance_from_a1_to_a2, 1), ForceMode2D.Force);
            }
        }
    }
}