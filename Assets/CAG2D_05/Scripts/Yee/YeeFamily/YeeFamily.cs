using System.Collections.Generic;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class YeeFamily
    {
        public int NumElement;
        public Color[] Colors = {Color.white};
        public Dictionary<string, object> YeeFamilyDict = new Dictionary<string, object>();
        public List<object> YeeFamily_list = new List<object>();
        public Dictionary<string, object> YeeType_dict = new Dictionary<string, object>();
        // public List<object> YeeType = new List<object>();
        public List<string> YeeType = new List<string>();
        public Dictionary<string, object> YeeInterType_dict = new Dictionary<string, object>();
        // public List<object> YeeInterType = new List<object>();
        public List<string> YeeInterType = new List<string>();
        public Dictionary<string, object> YeeRule_dict = new Dictionary<string, object>();

        public YeeRule YeeRule;
        // public List<string> YeeRule = new List<string>();

        public YeeFamily()
        {
            NumElement = 0;
            YeeType.Add("");
            YeeType_dict.Add("YeeType", YeeType);
            YeeInterType.Add("");
            YeeInterType_dict.Add("YeeInterType", YeeInterType);
            // YeeRule.Add("");
            YeeRule_dict.Add("YeeRule", YeeRule);
            YeeFamily_list.Add(YeeType_dict);
            YeeFamily_list.Add(YeeInterType_dict);
            YeeFamily_list.Add(YeeRule_dict);
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
//         public YeeType YeeType;
//         public YeeInterType YeeInterType;
//         public YeeRule YeeRule;
//     }
}