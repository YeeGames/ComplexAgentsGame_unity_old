using UnityEngine;
using Random = UnityEngine.Random;

namespace CAG2D_05.Scripts
{
    public class Agents : MonoBehaviour
    {
        public GameSettings gameSettings;

        public Agent agent;
        public float radiusSize = 30f;
        // public YeeType2E[] yeeTypes = {YeeType2E.Yang, YeeType2E.Yin};
        public YeeType3E[] yeeTypes = {YeeType3E.Rock, YeeType3E.Scissors, YeeType3E.Cloth};
        public Color[] typesColors = {Color.red, Color.yellow, Color.blue};
        private YeeRule2E _yeeRule2E;

        private void Awake()
        {
            for (var t = 0; t < yeeTypes.Length; t++) // 遍历每一类yeeType，以生成agent
            {
                for (var i = 0; i < gameSettings.numAgent; i++) // 遍历单类yeeType之所有预定数量，以生成agent
                {
                    Agent a = Instantiate(agent);

                    Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                    a.aset.position = pos;
                    a.aset.velocity = Random.insideUnitCircle;
                    a.aset.yeeType3E = yeeTypes[t];
                    a.aset.color = typesColors[t];
                    a.aset.agentName = a.aset.agentBaseName + yeeTypes[t].ToString() + i.ToString();

                    a.Initialize(a.aset, a.rset);
                }
            }
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