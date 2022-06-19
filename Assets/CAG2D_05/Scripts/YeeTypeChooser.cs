// // using CAG2D_05.Scripts.Yee;
//
// namespace CAG2D_05.Scripts
// {
//     public class YeeTypeChooser
//     {
//         private YeeTypeFamily yeeType;
//
//         private static YeeRule yeeRule;
//
//         public static YeeRule ChooseYeeType(YeeTypeFamily yeeTypeFamily)
//         {
//             switch (yeeTypeFamily)
//             {
//                 case YeeTypeFamily.YeeType2E:
//                     yeeRule = new Yee2ERule();
//                     // yeeType = YeeTypeFamily.Yee2ERule;
//                     break;
//                 case YeeTypeFamily.YeeType3E:
//                     yeeRule = new Yee3ERule();
//                     // yeeType = YeeTypeFamily.Yee3ERule;
//                     break;
//                 default:
//                     break;
//             }
//
//             return yeeRule;
//         }
//     }
// }