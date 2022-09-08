using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class SliderComponent: BaseComponent
    {
        public SliderComponent() : base()
        {
            model = new SliderModel();
            controller = new SliderController((SliderModel)model);
            view = new SliderView((SliderController)controller, (SliderModel)model);
        }
    }
}