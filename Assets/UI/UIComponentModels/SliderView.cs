using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class SliderView: ComponentView
    {
        private Slider slider;
        SliderModel model;
        private float scale;

        public SliderView(SliderModel m) : base()
        {
            model = m;
            model.onSliderChanged += updateView;
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

        public void updateView(float v)
        {
            slider.update(v);
            onSliderChanged(v);
        }

        override public void updateUI()
        {
            if (prefabInstance != null && scale != prefabInstance.transform.localScale.x)
            {
                scale = prefabInstance.transform.localScale.x;
                model.changeData(scale);
            }
        }
    }
}