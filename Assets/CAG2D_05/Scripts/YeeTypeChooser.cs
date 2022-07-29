// using CAG2D_05.Scripts.yee;

using System;
using System.Collections.Generic;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class YeeTypeChooser
    {
        // public static YeeTypeFamilyEnum _yeeTypeFamily;
        public static YeeType _yeeType;
        public static Yee2EType _yee2EType;
        public static Yee3EType _yee3EType;
        public static Yee _yee;
        public static YeeFamily _yeeFamily;

        public static YeeRule yeeRule;
        // public List<Enum> yeeTypeList;
        // public List<Enum> yee3ETypeList;


        // public static YeeRule ChooseYeeRule(GameObject gameObject, YeeTypeFamilyEnum yeeTypeFamily)
        // {
        //     switch (yeeTypeFamily)
        //     {
        //         case YeeTypeFamilyEnum.YeeType2E:
        //             yeeRule = gameObject.AddComponent<Yee2ERule>();
        //             // yeeFamilyEnum = YeeTypeFamilyEnum.YeeType2E;
        //             break;
        //         case YeeTypeFamilyEnum.YeeType3E:
        //             yeeRule = gameObject.AddComponent<Yee3ERule>();
        //             // yeeFamilyEnum = YeeTypeFamilyEnum.YeeType3E;
        //             break;
        //         default:
        //             break;
        //     }
        //
        //     return yeeRule;
        // }


        public static YeeFamily ChooseYeeFamily(GameObject gameObject, YeeFamilyEnum yeeFamilyEnum)
        {
            switch (yeeFamilyEnum)
            {
                case YeeFamilyEnum.Yee2E:
                    // _yeeFamily = new Yee2E();
                    _yeeFamily = gameObject.AddComponent<Yee2E>();
                    break;
                case YeeFamilyEnum.Yee3E:
                    // _yeeFamily = new Yee3E();
                    _yeeFamily = gameObject.AddComponent<Yee3E>(); //BUG
                    break;
                default:
                    break;
            }


            return _yeeFamily;
        }

        public static YeeType ChooseYeeType(YeeFamilyEnum yeeFamilyEnum)
        {
            YeeType yeeType = null;
            switch (yeeFamilyEnum)
            {
                case YeeFamilyEnum.Yee2E:
                    yeeType = new Yee2EType();
                    // _yeeFamily = new Yee2E();
                    // _yeeFamily = gameObject.AddComponent<Yee2E>();
                    break;
                case YeeFamilyEnum.Yee3E:
                    yeeType = new Yee3EType();
                    // _yeeFamily = new Yee3E();
                    // _yeeFamily = gameObject.AddComponent<Yee3E>();
                    break;
                default:
                    break;
            }


            return yeeType;
        }

        public static Yee ChooseYee(GameObject gameObject, YeeFamilyEnum yeeFamilyEnum)
        {
            switch (yeeFamilyEnum)
            {
                case YeeFamilyEnum.Yee2E:
                    // _yeeFamily = new Yee2E();
                    _yeeFamily = gameObject.AddComponent<Yee2E>();
                    break;
                case YeeFamilyEnum.Yee3E:
                    // _yeeFamily = new Yee3E();
                    _yeeFamily = gameObject.AddComponent<Yee3E>();
                    break;
                default:
                    break;
            }

            _yee.YeeFamily = _yeeFamily; //BUG

            return _yee;
        }
    }
}