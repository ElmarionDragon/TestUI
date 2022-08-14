using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class SliderComponent: BaseComponent
    {
        SliderModel model;

        public SliderComponent(): base()
        {
            model = new SliderModel();
            view = new SliderView(model);
        }
    }
}