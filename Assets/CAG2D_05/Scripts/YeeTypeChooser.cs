// using CAG2D_05.Scripts.Yee;

using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class YeeTypeChooser
    {
        private YeeTypeFamily yeeType;

        private static YeeRule yeeRule;

        public static YeeRule ChooseYeeType(GameObject gameObject,YeeTypeFamily yeeTypeFamily)
        {
            switch (yeeTypeFamily)
            {
                case YeeTypeFamily.YeeType2E:
                    yeeRule = gameObject.AddComponent<YeeRule2E>();
                    // yeeRule = new YeeRule2E();
                    break;
                case YeeTypeFamily.YeeType3E:
                    yeeRule = gameObject.AddComponent<YeeRule3E>();
                    // yeeRule = new YeeRule3E();
                    break;
                default:
                    break;
            }

            return yeeRule;
        }
    }
}