using System.Collections.Generic;
using UnityEngine;

namespace CAG2D_05.Scripts
{
    public abstract class YeeType
    {
        private int _numElement;
        private Color[] _colors;
        private string[] _yeeTypes;

        public virtual int setNumElement()
        {
            _numElement = 1;
            return _numElement;
        }


        public int NumElement
        {
            get => _numElement;
            set => _numElement = value;
        }

        public virtual Color[] Colors
        {
            get => _colors;
            set => _colors = value;
        }

        public virtual string[] YeeTypes
        {
            get => _yeeTypes;
            set => _yeeTypes = value;
        }
    }
}