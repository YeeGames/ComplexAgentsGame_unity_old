using System.Collections.Generic;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class YeeFamily : MonoBehaviour
    {
        [HideInInspector] public YeeType yeeType;
        [HideInInspector] public Dictionary<string, object> YeeFamilyDict = new Dictionary<string, object>();
        [HideInInspector] public List<object> YeeFamily_list = new List<object>();
        [HideInInspector] public Dictionary<string, List<string>> YeeType_dict = new Dictionary<string, List<string>>();
        [HideInInspector] public List<string> YeeTypes = new List<string>();
        [HideInInspector] public Dictionary<string, object> YeeInterType_dict = new Dictionary<string, object>();
        [HideInInspector] public List<string> YeeInterTypes = new List<string>();
        [HideInInspector] public Dictionary<string, object> YeeRule_dict = new Dictionary<string, object>();
        [HideInInspector] public YeeRule YeeRule;

        public YeeFamily()
        {
        }
    }

}