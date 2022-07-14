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
            // YeeType.Add(Yee2ETypeEnum.Yang);
            // YeeType.Add(Yee2ETypeEnum.Yin);
            YeeType.Add("Yang");
            YeeType.Add("Yin");
            YeeType_dict.Add("YeeType", YeeType);
            // YeeInterType.Add(Yee2EInterTypeEnum.Me);
            // YeeInterType.Add(Yee2EInterTypeEnum.You);
            YeeInterType.Add("Me");
            YeeInterType.Add("You");
            YeeInterType_dict.Add("YeeInterType", YeeInterType);
            // YeeRule.Add("Yee2ERule");
            YeeRule_dict.Add("YeeRule", YeeRule);
            YeeFamily_list.Add(YeeType_dict);
            YeeFamily_list.Add(YeeInterType_dict);
            YeeFamily_list.Add(YeeRule_dict);
        }
    }


//     public class Yee2EDict : Yee
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
//             YeeType = YeeTypeFamilyEnum.YeeType2E;
//             YeeInterTypeFamilyEnum = YeeInterTypeFamilyEnum.Yee2EInterType;
//             YeeRule = new Yee2ERule();
//         }
}