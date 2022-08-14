using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class SliderModel : ComponentModel
    {
        private Slider slider;
        public event Action<float> onSliderChanged;

        public SliderModel() : base()
        {
        }
        public void changeData(float v)
        {
            onSliderChanged(v);
        }
    }
}