using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class SliderController: ComponentController
    {
        public SliderView view;
        public SliderModel model;

        public SliderController(SliderModel m): base()
        {
            model = m;
        }

        public void SliderChanged(float v)
        {
            model.setSize(v);
        }
    }
}