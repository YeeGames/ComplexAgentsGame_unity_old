using System;
using System.CodeDom;
using UnityEngine;
using Random = UnityEngine.Random;
using CAG2D_05.Scripts;

namespace CAG2D_05.Scripts
{
    public class Agents : MonoBehaviour
    {
        [HideInInspector] public GameSettings gameSettings;

        [HideInInspector] public Agent agent;

        [SerializeField] private float radiusSize = 30f;

        [SerializeField] private Yee2ERule _yee2ERule;

        [SerializeField] private YeeFamilyEnum yeeFamilyEnum;

        [SerializeField] private YeeRule yeeRule;
        [SerializeField] private Yee yee;
        [SerializeField] private YeeType yeeType;
        // private YeeTypeChooserNotStatics _yeeTypeChooserNotStatics = new YeeTypeChooserNotStatics();

        /// <summary>
        /// 使用静态的YeeTypeChooser
        /// </summary>
        private void Awake()
        {
            yeeType = YeeTypeChooser.ChooseYeeType(gameSettings.yeeFamilyEnum);

            for (var t = 0; t < yeeType.NumElement; t++) // 遍历每一类yeeType，以生成agent
            {
                for (var i = 0; i < gameSettings.numAgent; i++) // 遍历单类yeeType之所有预定数量，以生成agent
                {
                    Agent a = Agent.Instantiate(agent);

                    Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;

                    a.aset.position = pos;
                    a.aset.velocity = Random.insideUnitCircle;
                    a.aset.id = i.ToString();
                    a.aset.YeeType = yeeType.YeeTypes[t];
                    a.aset.color = yeeType.Colors[t];
                    // a.aset.agentName = a.aset.agentBaseName + a.aset.YeeType + i.ToString();

                    a.Initialize(a.aset, a.rset);

                    // a.agentRuleEffector = GameObject.Find("AgentRuleEffector").gameObject;
                    // a.yeeRule = YeeTypeChooser.ChooseYeeRule(a.agentRuleEffector, gameSettings.yeeFamilyEnum);
                }
            }
        }


        // /// <summary>
        // /// 使用非静态的YeeTypeChooser
        // /// </summary>
        // private void Awake()
        // {
        //     yeeType = _yeeTypeChooserNotStatics.ChooseYeeType(gameSettings.yeeFamilyEnum);
        //
        //     for (var t = 0; t < yeeType.NumElement; t++) // 遍历每一类yeeType，以生成agent
        //     {
        //         for (var i = 0; i < gameSettings.numAgent; i++) // 遍历单类yeeType之所有预定数量，以生成agent
        //         {
        //             Agent a = Agent.Instantiate(agent);
        //
        //             Vector2 pos = (Vector2) (this.transform.position) + Random.insideUnitCircle * radiusSize;
        //             
        //             a.aset.position = pos;
        //             a.aset.velocity = Random.insideUnitCircle;
        //             a.aset.id = i.ToString();
        //             a.aset.YeeType = yeeType.YeeTypes[t];
        //             a.aset.color = yeeType.Colors[t];
        //             // a.aset.agentName = a.aset.agentBaseName + a.aset.YeeType + i.ToString();
        //
        //             a.Initialize(a.aset, a.rset);
        //             
        //             // a.agentRuleEffector = GameObject.Find("AgentRuleEffector").gameObject;
        //             // a.yeeRule = YeeTypeChooser.ChooseYeeRule(a.agentRuleEffector, gameSettings.yeeFamilyEnum);
        //
        //         }
        //     }
        // }

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