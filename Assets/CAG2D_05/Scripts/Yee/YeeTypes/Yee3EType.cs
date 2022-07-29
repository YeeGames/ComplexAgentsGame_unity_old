using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public class Yee3EType : YeeType
    {
        public Yee3ETypeEnum Yee3ETypeEnum;
        
        public Yee3EType()
        {
            this.NumElement = 3;
            this.Colors = new Color[] {Color.red, Color.yellow, Color.blue};
            this.YeeTypes = new string[] {"Rock", "Scissors", "Cloth"};
        }
    }
}