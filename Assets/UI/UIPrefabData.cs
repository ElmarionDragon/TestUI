using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    [Serializable]
    public class UIPrefabData
    {
        public string name;
        public GameObject prefab;

        public UIComponentType[] uiComponents;

        public enum UIComponentType
        {
            Slider,
            Pose,
            IP
        }

        public static BaseComponent createUIComponent(UIComponentType uiType)
        {
            BaseComponent component = null;
            if (uiType == UIComponentType.IP)
            {
                component = new IPComponent();
            }
            if (uiType == UIComponentType.Slider)
            {
                component = new SliderComponent();
            }
            if (uiType == UIComponentType.Pose)
            {
                component = new PoseComponent();
            }
            return component;
        }
    }
}
