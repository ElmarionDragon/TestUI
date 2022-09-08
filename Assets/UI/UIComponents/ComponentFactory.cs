using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestUI
{
    public class ComponentFactory
    {
        public static BaseComponent createUIComponent(UIPrefabData.UIComponentType uiType)
        {
            BaseComponent component = null;
            if (uiType == UIPrefabData.UIComponentType.IP)
            {
                component = new IPComponent();
            }
            if (uiType == UIPrefabData.UIComponentType.Slider)
            {
                component = new SliderComponent();
            }
            if (uiType == UIPrefabData.UIComponentType.Pose)
            {
                component = new PoseComponent();
            }
            return component;
        }
    }
}
