using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class SliderModel: ComponentModel
    {
        private Slider slider;

        public SliderModel(): base()
        {
        }

        override public VisualElement createUIComponent()
        {
            slider = new Slider();
            slider.changed += onSliderChanged;
            return slider;
        }

        override public void updateComponent()
        {
            onSliderChanged(slider.slider.value);
        }

        private void onSliderChanged(float v)
        {
            prefabInstance.transform.localScale = new Vector3(v, v, v);
        }
    }
}