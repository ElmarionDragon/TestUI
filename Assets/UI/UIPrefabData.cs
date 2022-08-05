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

        public static ComponentModel createUIComponent(UIComponentType uiType)
        {
            ComponentModel component = null;
            if (uiType == UIComponentType.IP)
            {
                component = new IPModel();
            }
            if (uiType == UIComponentType.Pose)
            {
                component = new PoseModel();
            }
            if (uiType == UIComponentType.Slider)
            {
                component = new SliderModel();
            }
            return component;
        }
    }
}
