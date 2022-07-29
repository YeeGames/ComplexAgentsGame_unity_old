using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class Yee2EType : YeeType
    {
        private Yee2ETypeEnum Yee2ETypeEnum;

        public Yee2EType()
        {
            this.NumElement = 2;
            this.Colors = new Color[] {Color.red, Color.blue};
            this.YeeTypes = new string[] {"Yang", "Yin"};
        }
    }
}