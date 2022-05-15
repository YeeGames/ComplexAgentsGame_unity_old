using UnityEngine;
using Random = UnityEngine.Random;

namespace ComplexAgentsGame2D.Scripts
{
    public class Agents : MonoBehaviour
    {
        public GameSettings gameSettings;
        public AgentSettings agentSettings;
        public float speed;
        public YeeType[] yeeTypes;
        public YeeType yeeType;
        public Agent agentPrefab;
        public Color agentsColor = Color.white;
        public float radiusSize = 10f;
        public int numAgent = 10;


        private enum E1Type : short
        {
            Tai
        }

        private enum E2Type : short
        {
            Yang,
            Yin
        }

        private enum E3Type : short
        {
            Tian,
            Ren,
            Di
        }

        private void Awake()
        {
            for (var i = 0; i < numAgent; i++)
            {
                Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                Agent a = Instantiate(agentPrefab);
                a.Initialize();
                
                a.yeeType = YeeType.Tai;
                a.SetPosition(pos);
                a.SetVelocity(Random.insideUnitCircle, speed);
                a.SetColor(agentsColor);
            }

            // agentPrefab.gameSettings.aType = gameSettings.Type.Yin;
            // agentPrefab.SetColor(Color.blue);
            // 加上Yin和Yang  
            // gameSettings.EType[] elements2 = {gameSettings.etype.Yang, gameSettings.Type.Yin};
            // for (var i = 0; i < 2; i++)
            // {
            //     for (var a = 0; a < numAgent; a++)
            //     {
            //         Vector2 pos = (Vector2) (this.transform.position) +
            //                       (Vector2) (this.transform.forward * radiusSize) +
            //                       Random.insideUnitCircle * radiusSize;
            //         Agent aYin = Instantiate(agentPrefab);
            //         aYin.SetPosition(pos);
            //         Debug.Log("Position of " +
            //                   gameSettings.Type.Yin.ToString() + " agent " + a.ToString() + " is " + pos.ToString());
            //         Vector2 vel = Random.insideUnitCircle;
            //         aYin.transform.forward = vel;
            //         Debug.Log("Velocity of agent " + a.ToString() + " is " + vel.ToString());
            //         aYin.gameSettings.aType = gameSettings.Type.Yin;
            //         aYin.SetColor(Color.blue);
            //     }
            // }
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void FixedUpdate()
        {
        }
    }
}