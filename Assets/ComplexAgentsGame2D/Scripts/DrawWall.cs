using UnityEngine;

namespace ComplexAgentsGame2D.Scripts
{
    public class DrawWall : MonoBehaviour
    {
        public class NewBehaviourScript : MonoBehaviour
        {
            Vector3 v;                   //圆心
            float R;					//半径
            int positionCount;			//完成一个圆的总点数，
            float angle;				//转角，三个点形成的两段线之间的夹角
            Quaternion quaternion;				//Quaternion四元数
            LineRenderer line;          //LineRenderer组件
 
            void Awake()
            {
                v = new Vector2(0, 0);
                R = 50;
                positionCount = 360;
                angle = 360f / (positionCount - 1);
                line = GetComponent<LineRenderer>();
                line.positionCount = positionCount;
                DrawCircle();
            }
            void Update()
            {
            }
            void DrawCircle()
            {
                for (int i = 0; i < positionCount; i++)
                {
                    if (i != 0)
                    {
                        //默认围着z轴画圆，所以z值叠加，叠加值为每两个点到圆心的夹角
                        quaternion = Quaternion.Euler(quaternion.eulerAngles.x, quaternion.eulerAngles.y, quaternion.eulerAngles.z + angle);
                    }
                    //Quaternion与Vector3的右乘操作（*）返回一个将原有向量做旋转操作后的新向量.列如：Quaternion.Euler(0, 90, 0) * Vector3(0.0, 0.0, -10) 相当于把向量Vector3(0.0, 0.0, -10)绕y轴旋转90度，得到的结果为Vector3(-10, 0.0.0.0)
                    Vector3 forwardPosition = v + quaternion * Vector3.down * R;
                    line.SetPosition(i, forwardPosition);
                }
            }
        }


    }
}