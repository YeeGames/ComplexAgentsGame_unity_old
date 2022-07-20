using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class Yee3E : YeeFamily
    {
        public Yee3EType Yee3EType;

        public new int NumElement = 3;

        public Color[] Colors = {Color.red, Color.yellow, Color.blue};
        // public Dictionary<string, object> Yee3EDict = new Dictionary<string, object>();
        // public List<object> Yee3EList = new List<object>();
        // public Dictionary<string, object> Yee3ETypeDict = new Dictionary<string, object>();
        // public List<string> Yee3EType = new List<string>();
        // public Dictionary<string, object> Yee3EInterTypeDict = new Dictionary<string, object>();
        // public List<string> Yee3EInterType = new List<string>();
        // public Dictionary<string, object> Yee3ERuleDict = new Dictionary<string, object>();
        // public List<string> Yee3ERule = new List<string>();

        public Yee3E()
        {
            // NumElement=3;
            // YeeTypes.Add(Yee3ETypeEnum.Rock);
            // YeeTypes.Add(Yee3ETypeEnum.Scissors);
            // YeeTypes.Add(Yee3ETypeEnum.Cloth);
            YeeTypes.Add("Rock");
            YeeTypes.Add("Scissors");
            YeeTypes.Add("Cloth");
            YeeType_dict.Add("YeeTypes", YeeTypes); //BUG
            // YeeInterTypes.Add(Yee3EInterTypeEnum.Self);
            // YeeInterTypes.Add(Yee3EInterTypeEnum.Ke);
            // YeeInterTypes.Add(Yee3EInterTypeEnum.BeKe);
            YeeInterTypes.Add("Self");
            YeeInterTypes.Add("Ke");
            YeeInterTypes.Add("BeKe");
            YeeInterType_dict.Add("YeeInterTypes", YeeInterTypes);
            // YeeRule.Add("Yee3ERule");
            YeeRule_dict.Add("YeeRule", YeeRule);
            YeeFamily_list.Add(YeeType_dict);
            YeeFamily_list.Add(YeeInterType_dict);
            YeeFamily_list.Add(YeeRule_dict);
        }
    }
//     public class Yee3EDict : yee
//     {
//         public Yee3ETypeEnum Yee3ETypeEnum;
//         public Yee3EInterTypeEnum Yee3EInterTypeEnum;
//
//         public Yee3EDict()
//         {
//             NumElement = 3;
//             Colors = new Color[]
//                 {
//                     Color.red,
//                     Color.yellow,
//                     Color.blue
//                 }
//                 ;
//             YeeTypes = YeeTypeFamilyEnum.YeeType3E;
//             YeeInterTypeFamilyEnum = YeeInterTypeFamilyEnum.Yee3EInterType;
//             YeeRule = new Yee3ERule();
//         }
//     }
}