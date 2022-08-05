using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class UIPrefabViewController : Toggle
    {
        public UIPrefabData uiPrefabData;
        public GameObject prefabInstance;
        public VisualElement ui;

        public UIPrefabViewController(UIPrefabData p) : base()
        {
            uiPrefabData = p;
            label = uiPrefabData.name;
            ui = createUI();
            ui.style.display = DisplayStyle.None;

            this.RegisterValueChangedCallback(v =>
            {
                bool flag = v.newValue;
                if (flag)
                {
                    ui.style.display = DisplayStyle.Flex;
                    prefabInstance = GameObject.Instantiate(uiPrefabData.prefab);
                }
                else
                {
                    ui.style.display = DisplayStyle.None;
                    GameObject.Destroy(prefabInstance);
                }
            });
        }

        public VisualElement createUI()
        {
            VisualElement container = new VisualElement();
            container.AddToClassList("container");
            container.name = uiPrefabData.name;

            Label title = new Label(uiPrefabData.name);
            title.AddToClassList("prefabTitle");
            container.Add(title);

            VisualElement vs;
            UIPrefabData.UIComponentType uiType;
            UIPrefabData.UIComponentType[] uiComponents = uiPrefabData.uiComponents;

            for (int i = 0; i < uiComponents.Length; i++)
            {
                uiType = uiComponents[i];
                vs = createUIComponent(uiType);
                container.Add(vs);
            }

            return container;
        }

        private VisualElement createUIComponent(UIPrefabData.UIComponentType uiType)
        {
            ComponentModel component = null;
            if (uiType == UIPrefabData.UIComponentType.IP)
            {
                component = new IPModel();
            }
            if (uiType == UIPrefabData.UIComponentType.Pose)
            {
                component = new PoseModel();
            }
            if (uiType == UIPrefabData.UIComponentType.Slider)
            {
                component = new SliderModel();
            }
            return component.ui;
        }
    }
}