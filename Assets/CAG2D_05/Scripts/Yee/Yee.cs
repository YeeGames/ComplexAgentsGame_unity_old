using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
// using Newtonsoft.Json;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    // 来源：[JSON转C#实体类](https://www.bejson.com/convert/json2csharp/)
    //如果好用，请收藏地址，帮忙分享。
//如果好用，请收藏地址，帮忙分享。


    // public class yee<YeeTypes> : MonoBehaviour
    public class Yee : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        [HideInInspector] public Yee2ETypeEnum yee2ETypeEnum;

        [HideInInspector] public Yee3ETypeEnum yee3ETypeEnum;

        public List<YeeType> enumToList<YeeType>() where YeeType:Enum
        {
            List<YeeType> yeeTypeList = Enum.GetValues(typeof(YeeType)).Cast<YeeType>().ToList();
            return yeeTypeList;
        }


        public YeeFamily YeeFamily { get; set; }

        public Dictionary<string, object> YeeFamily_dict = new Dictionary<string, object>();
        public List<object> YeeFamily_list = new List<object>();

        public Yee()
        {
            YeeFamily_list.Add(YeeFamily);
            YeeFamily_dict.Add("yeeFamily", YeeFamily_list);
        }
    }


    // public class Root
    // {
    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     public yee yee { get; set; }
    // }


    // public class YeeListClass
    // {
    //     // private int _numElement;
    //     // private Color[] _colors;
    //
    //     public Dictionary<string, object> yeeFamily = new Dictionary<string, object>();
    //     public List<object> YeeFamilyList = new List<object>();
    //     public Dictionary<string, object> YeeTypeFamilyDict = new Dictionary<string, object>();
    //     public List<string> YeeFamilyType = new List<string>();
    //     public Dictionary<string, object> YeeInterTypeFamilyDict = new Dictionary<string, object>();
    //     public List<string> YeeInterTypeFamily = new List<string>();
    //     public Dictionary<string, object> YeeRuleFamilyDict = new Dictionary<string, object>();
    //     public List<string> YeeRuleFamily = new List<string>();
    //
    //     public Dictionary<string, object> yee = new Dictionary<string, object>();
    //     public List<object> YeeList = new List<object>();
    //     public Dictionary<string, object> Yee2E = new Dictionary<string, object>();
    //     public List<object> Yee2EList = new List<object>();
    //     public Dictionary<string, object> Yee2ETypeDict = new Dictionary<string, object>();
    //     public List<string> Yee2EType = new List<string>();
    //     public Dictionary<string, object> Yee2EInterTypeDict = new Dictionary<string, object>();
    //     public List<string> Yee2EInterType = new List<string>();
    //     public Dictionary<string, object> Yee2ERuleDict = new Dictionary<string, object>();
    //     public List<string> Yee2ERule = new List<string>();
    //     public Dictionary<string, object> Yee3E = new Dictionary<string, object>();
    //     public List<object> Yee3EList = new List<object>();
    //     public Dictionary<string, object> Yee3ETypeDict = new Dictionary<string, object>();
    //     public List<string> Yee3EType = new List<string>();
    //     public Dictionary<string, object> Yee3EInterTypeDict = new Dictionary<string, object>();
    //     public List<string> Yee3EInterType = new List<string>();
    //     public Dictionary<string, object> Yee3ERuleDict = new Dictionary<string, object>();
    //     public List<string> Yee3ERule = new List<string>();
    //
    //
    //     public YeeListClass()
    //     {
    //         // // 方法一：
    //         yee yee = JsonConvert.DeserializeObject<yee>();
    //
    //         // // 方法二：
    //         // yee = setYeeFamily();
    //     }
    //
    //     /// <summary>
    //     /// 解析JSON为类？
    //     /// </summary>
    //     /// <param name="text"></param>
    //     /// <typeparam name="T"></typeparam>
    //     /// <returns></returns>
    //     public static T GetData<T>(string text) where T : class
    //     {
    //         T t = JsonUtility.FromJson<T>(text);
    //         return t;
    //     }
    //
    //     // protected YeeRule _yeeRule;
    //     //
    //     // public YeeRule YeeRule
    //     // {
    //     //     get => _yeeRule;
    //     //     set => _yeeRule = value;
    //     // }
    //
    //     private Dictionary<string, object> setYeeFamily(YeeFamilyEnum yeeFamily)
    //     {
    //         switch (yeeFamily)
    //         {
    //             case YeeFamilyEnum.Yee2E:
    //                 Scripts.yeeFamily
    //                 _yeeListClass._yeeListClass.yeeFamily.YeeTypeFamily.YeeTypes = new Yee2EType();
    //                 _yeeListClass.yeeFamily.YeeInterTypeFamily.YeeInterTypes = new Yee2EInterType();
    //                 _yeeListClass.yeeFamily.YeeRuleFamily.YeeRule = new Yee2ERule();
    //                 // _yee = gameObject.GetComponent<Yee2EDict>();
    //                 break;
    //             case YeeFamilyEnum.Yee3E:
    //                 _yeeListClass.yeeFamily.YeeTypeFamily.YeeTypes = new Yee3EType();
    //                 _yeeListClass.yeeFamily.YeeInterTypeFamily.YeeInterTypes = new Yee3EInterType();
    //                 _yeeListClass.yeeFamily.YeeRuleFamily.YeeRule = new Yee3ERule();
    //                 // _yee = gameObject.GetComponent<Yee3EDict>();
    //                 break;
    //             default:
    //                 break;
    //         }
    //
    //
    //         Yee2EType.Add("Yang");
    //         Yee2EType.Add("Yin");
    //         Yee2ETypeDict.Add("Yee2EType", Yee2EType);
    //         Yee2EInterType.Add("Me");
    //         Yee2EInterType.Add("You");
    //         Yee2EInterTypeDict.Add("Yee2EInterType", Yee2EInterType);
    //         Yee2ERule.Add("Yee2ERule");
    //         Yee2ERuleDict.Add("Yee2ERule", Yee2ERule);
    //         Yee2EList.Add(Yee2ETypeDict);
    //         Yee2EList.Add(Yee2EInterTypeDict);
    //         Yee2EList.Add(Yee2ERuleDict);
    //         Yee2E.Add("Yee2EDict", Yee2EList);
    //         YeeList.Add(Yee2E);
    //
    //         Yee3EType.Add("Rock");
    //         Yee3EType.Add("Scissors");
    //         Yee3EType.Add("Cloth");
    //         Yee3ETypeDict.Add("Yee3EType", Yee3EType);
    //         Yee3EInterType.Add("Self");
    //         Yee3EInterType.Add("Ke");
    //         Yee3EInterType.Add("BeKe");
    //         Yee3EInterTypeDict.Add("Yee3EInterType", Yee3EInterType);
    //         Yee3ERule.Add("Yee3ERule");
    //         Yee3ERuleDict.Add("Yee3ERule", Yee3ERule);
    //         Yee3EList.Add(Yee3ETypeDict);
    //         Yee3EList.Add(Yee3EInterTypeDict);
    //         Yee3EList.Add(Yee3ERuleDict);
    //         Yee3E.Add("Yee3EDict", Yee3EList);
    //         YeeList.Add(Yee3E);
    //         yee.Add("yee", YeeList);
    //
    //         // YeeFamily_dict.Add("YeeFamily_dict", YeeFamily_list);
    //         // YeeFamily_list.Add(YeeFamily_dict);
    //         // YeeTypes.Add("YeeTypes");
    //         // YeeFamily_list.Add(YeeTypes);
    //         // YeeFamily_list.Add(YeeInterTypeFaimly);
    //         // YeeFamily_list.Add(YeeRuleFaimly);
    //
    //         Debug.Log(yee);
    //
    //         return yee;
    //     }
    // }
}