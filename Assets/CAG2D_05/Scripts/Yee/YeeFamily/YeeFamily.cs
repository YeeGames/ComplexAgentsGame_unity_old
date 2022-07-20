using System.Collections.Generic;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class YeeFamily : MonoBehaviour
    {
        [HideInInspector] public YeeType yeeType;
        // [HideInInspector] public int NumElement = 3;
        // [HideInInspector] public Color[] Colors = {Color.white};
        [HideInInspector] public Dictionary<string, object> YeeFamilyDict = new Dictionary<string, object>();
        [HideInInspector] public List<object> YeeFamily_list = new List<object>();

        [HideInInspector] public Dictionary<string, List<string>> YeeType_dict = new Dictionary<string, List<string>>();

        // [HideInInspector] public List<object> YeeTypes = new List<object>();
        [HideInInspector] public List<string> YeeTypes = new List<string>();

        [HideInInspector] public Dictionary<string, object> YeeInterType_dict = new Dictionary<string, object>();

        // [HideInInspector] public List<object> YeeInterTypes = new List<object>();
        [HideInInspector] public List<string> YeeInterTypes = new List<string>();
        [HideInInspector] public Dictionary<string, object> YeeRule_dict = new Dictionary<string, object>();

        [HideInInspector] public YeeRule YeeRule;
        // [HideInInspector] public List<string> YeeRule = new List<string>();

        public YeeFamily()
        {
            // // NumElement = 0;
            // YeeTypes.Add("");
            // YeeType_dict.Add("YeeTypes", YeeTypes);
            // YeeInterTypes.Add("");
            // YeeInterType_dict.Add("YeeInterTypes", YeeInterTypes);
            // // YeeRule.Add("");
            // YeeRule_dict.Add("YeeRule", YeeRule);
            // YeeFamily_list.Add(YeeType_dict);
            // YeeFamily_list.Add(YeeInterType_dict);
            // YeeFamily_list.Add(YeeRule_dict);
        }
    }


//     public class YeeFamily_dict
//     {
//         private Dictionary<string, string> _yeeFamilyList = new Dictionary<string, string>();
//
//         public Dictionary<string, string> YeeFamily_list
//         {
//             get => _yeeFamilyList;
//             set => _yeeFamilyList = value;
//         }
//         
//         
//
//         public YeeFamilyEnum YeeFamilyEnum;
//         public YeeTypes YeeTypes;
//         public YeeInterTypes YeeInterTypes;
//         public YeeRule YeeRule;
//     }
}