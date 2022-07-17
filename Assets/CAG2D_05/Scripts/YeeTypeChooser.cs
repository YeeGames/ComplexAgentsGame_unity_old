// using CAG2D_05.Scripts.Yee;

using System;
using System.Collections.Generic;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class YeeTypeChooser
    {
        private static YeeTypeFamilyEnum _yeeTypeFamily;
        private static YeeType _yeeType;
        private static Yee _yee;
        private static YeeRule yeeRule;
        private List<Enum> yeeTypeList;
        private List<Enum> yee3ETypeList;


        public static YeeRule ChooseYeeRule(GameObject gameObject, YeeTypeFamilyEnum yeeTypeFamily)
        {
            switch (yeeTypeFamily)
            {
                case YeeTypeFamilyEnum.YeeType2E:
                    yeeRule = gameObject.AddComponent<Yee2ERule>();
                    // yeeFamily = YeeTypeFamilyEnum.YeeType2E;
                    break;
                case YeeTypeFamilyEnum.YeeType3E:
                    yeeRule = gameObject.AddComponent<Yee3ERule>();
                    // yeeFamily = YeeTypeFamilyEnum.YeeType3E;
                    break;
                default:
                    break;
            }

            return yeeRule;
        }


        // public static List<Enum> ChooseYeeFamily(YeeTypeFamilyEnum yeeTypeFamily)
        // {
        //     switch (yeeTypeFamily)
        //     {
        //         case YeeTypeFamilyEnum.YeeType2E:
        //             // yeeTypeList = _yee<Yee2ETypeEnum>.enumToList<Yee2ETypeEnum>();
        //             YeeFamily yeeFamily=;
        //                 return _yeeFamily.;
        //             _yeeTypeFamily = YeeTypeFamilyEnum.YeeType2E;
        //             break;
        //         case YeeTypeFamilyEnum.YeeType3E:
        //             return _yeeType.Yee3ETypeEnum;
        //             _yeeTypeFamily = YeeTypeFamilyEnum.YeeType3E;
        //             break;
        //         default:
        //             break;
        //     }
        //
        //     return _yeeType;
        // }

        public static Yee ChooseYee(GameObject gameObject, YeeFamilyEnum yeeFamilyEnum)
        {
            switch (yeeFamilyEnum)
            {
                case YeeFamilyEnum.Yee2E:
                    _yee.YeeFamily = new Yee2E();
                    // _yeeListClass = gameObject.GetComponent<Yee2EDict>();
                    break;
                case YeeFamilyEnum.Yee3E:
                    _yee.YeeFamily = new Yee3E(); //BUG
                    // _yeeListClass = gameObject.GetComponent<Yee3EDict>();
                    break;
                default:
                    break;
            }

            return _yee;
        }
    }
}