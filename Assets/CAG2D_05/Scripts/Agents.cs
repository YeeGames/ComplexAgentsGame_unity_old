using System;
using System.CodeDom;
using UnityEngine;
using Random = UnityEngine.Random;
using CAG2D_05.Scripts;

namespace CAG2D_05.Scripts
{
    public class Agents : MonoBehaviour
    {
        public GameSettings gameSettings;

        public Agent agent;

        public float radiusSize = 30f;

        // public YeeType2E[] yeeType2Es = {YeeType2E.Yang, YeeType2E.Yin};
        // public Yee3ETypeEnum[] yeeType3Es = {Yee3ETypeEnum.Rock, Yee3ETypeEnum.Scissors, Yee3ETypeEnum.Cloth};
        // public Color[] typesColors = {Color.red, Color.yellow, Color.blue};
        private Yee2ERule _yee2ERule;

        public YeeFamilyEnum yeeFamilyEnum;

        // public yeeFamilyEnum yeeFamilyEnum;
        [HideInInspector] public YeeRule yeeRule;
        [HideInInspector] public Yee yee;
        public YeeFamily yeeFamily;
        [HideInInspector] public YeeType yeeType;


        private void Awake()
        {
            // yee = YeeTypeChooser.ChooseYee(agent.agentRuleEffector, gameSettings.yeeFamilyEnum);
            // yeeFamilyEnum = YeeTypeChooser.ChooseYeeFamily(agent.agentRuleEffector, gameSettings.yeeFamilyEnum); //BUG
            yeeType = YeeTypeChooser.ChooseYeeType(gameSettings.yeeFamilyEnum);
            // const int numElement = 3; //FIXME

            for (var t = 0; t < yeeType.NumElement; t++) // 遍历每一类yeeType，以生成agent
            {
                for (var i = 0; i < gameSettings.numAgent; i++) // 遍历单类yeeType之所有预定数量，以生成agent
                {
                    Agent a = Instantiate(agent); //BUG

                    Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
                    a.aset.position = pos;
                    a.aset.velocity = Random.insideUnitCircle;
                    a.aset.YeeType = yeeType.YeeTypes[t];
                    a.aset.YeeInterType = null; // FIXME
                    // a.aset.color = yeeFamilyEnum.Colors[t];
                    a.aset.color = yeeType.Colors[t];
                    a.aset.agentName = a.aset.agentBaseName + a.aset.YeeType + i.ToString();

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