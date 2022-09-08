using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class SliderView: ComponentView, ComponentObserver
    {
        SliderModel model;
        SliderController controller;
        private Slider slider;
        private float scale;

        public SliderView(SliderController c, SliderModel m) : base()
        {
            model = m;
            controller = c;
            model.registerObserver(this);
            // model.onSliderChanged += updateView;
        }

        override public VisualElement createUIComponent()
        {
            slider = new Slider();
            slider.changed += SliderChanged;
            return slider;
        }

        override public void updateComponent()
        {
            SliderChanged(slider.slider.value);
        }

        private void SliderChanged(float v)
        {
            controller.SliderChanged(v);
        }

        public void updateObserver()
        {
            float v = model.size;
            slider.update(v);
            prefabInstance.transform.localScale = new Vector3(v, v, v);
        }
    }
}