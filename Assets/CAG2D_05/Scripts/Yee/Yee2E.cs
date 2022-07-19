using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class Yee2E : YeeFamily
    {
        public new const int NumElement = 2;

        public Color[] Colors = {Color.red, Color.blue};
        // public Dictionary<string, object> Yee2EDict = new Dictionary<string, object>();
        // public List<object> Yee2EList = new List<object>();
        // public Dictionary<string, object> Yee2ETypeDict = new Dictionary<string, object>();
        // public List<string> Yee2EType = new List<string>();
        // public Dictionary<string, object> Yee2EInterTypeDict = new Dictionary<string, object>();
        // public List<string> Yee2EInterType = new List<string>();
        // public Dictionary<string, object> Yee2ERuleDict = new Dictionary<string, object>();
        // public List<string> Yee2ERule = new List<string>();

        public Yee2ETypeEnum Yee2ETypeEnum;

        public Yee2E()
        {
            // YeeTypes.Add(Yee2ETypeEnum.Yang);
            // YeeTypes.Add(Yee2ETypeEnum.Yin);
            YeeTypes.Add("Yang");
            YeeTypes.Add("Yin");
            YeeType_dict.Add("YeeTypes", YeeTypes);
            // YeeInterTypes.Add(Yee2EInterTypeEnum.Me);
            // YeeInterTypes.Add(Yee2EInterTypeEnum.You);
            YeeInterTypes.Add("Me");
            YeeInterTypes.Add("You");
            YeeInterType_dict.Add("YeeInterTypes", YeeInterTypes);
            // YeeRule.Add("Yee2ERule");
            YeeRule_dict.Add("YeeRule", YeeRule);
            YeeFamily_list.Add(YeeType_dict);
            YeeFamily_list.Add(YeeInterType_dict);
            YeeFamily_list.Add(YeeRule_dict);
        }
    }


//     public class Yee2EDict : yee
//     {
//         public Yee2ETypeEnum Yee2ETypeEnum;
//         public Yee2EInterTypeEnum Yee2EInterTypeEnum;
//
//         // public Yee2EDict(int numElement, Color[] colors, YeeTypeFamilyEnum yeeFamily, YeeRule yeeRule, YeeTypeFamilyEnum yeeFamily, YeeInterTypeFamilyEnum yeeInterType, YeeRule yeeRule) : base(numElement, colors, yeeFamily, yeeInterType, yeeRule)
//         // {
//         //     numElement = 2;
//         //     colors = new Color[]
//         //         {
//         //             Color.red, Color.blue
//         //         }
//         //         ;
//         //     yeeFamily = yeeFamily;
//         //     yeeRule = yeeInterType;
//         //     yeeRule = new Yee2ERule();
//         // }
//
//         public Yee2EDict()
//         {
//             NumElement = 2;
//             Colors = new Color[]
//                 {
//                     Color.red,
//                     Color.blue
//                 }
//                 ;
//             YeeTypes = YeeTypeFamilyEnum.YeeType2E;
//             YeeInterTypeFamilyEnum = YeeInterTypeFamilyEnum.Yee2EInterType;
//             YeeRule = new Yee2ERule();
//         }
}