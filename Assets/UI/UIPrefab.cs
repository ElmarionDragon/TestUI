using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    [Serializable]
    public class UIPrefab
    {
        public string name;
        public GameObject prefab;

        public UIComponentType[] uiComponents;

        public enum UIComponentType
        {
            Slider,
            Pose,
            IP,
            SliderX
        } 
    }
}
