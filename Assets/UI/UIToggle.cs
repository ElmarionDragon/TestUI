using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class UIToggle : Toggle
    {
        public UIPrefab uiPrefab;
        public GameObject prefab;

        public VisualElement ui;

        public UIToggle(UIPrefab p) : base()
        {
            uiPrefab = p;
            label = uiPrefab.name;
            ui = createUI();
            ui.style.display = DisplayStyle.None;

            this.RegisterValueChangedCallback(v =>
            {
                bool flag = v.newValue;
                if (flag)
                {
                    ui.style.display = DisplayStyle.Flex;
                    prefab = GameObject.Instantiate(uiPrefab.prefab);
                }
                else
                {
                    ui.style.display = DisplayStyle.None;
                    GameObject.Destroy(prefab);
                }
            });
        }

        public VisualElement createUI()
        {
            VisualElement container = new VisualElement();
            container.AddToClassList("container");
            container.name = uiPrefab.name;

            Label title = new Label(uiPrefab.name);
            title.AddToClassList("prefabTitle");
            container.Add(title);

            VisualElement vs;
            UIPrefab.UIComponentType uiType;
            UIPrefab.UIComponentType[] uiComponents = uiPrefab.uiComponents;

            for (int i = 0; i < uiComponents.Length; i++)
            {
                uiType = uiComponents[i];
                vs = createUIComponent(uiType);
                container.Add(vs);
            }

            return container;
        }

        private VisualElement createUIComponent(UIPrefab.UIComponentType uiType)
        {
            if (uiType == UIPrefab.UIComponentType.IP)
            {
                IP vs = new IP();
                vs.changed += onIPChanged;
                return vs;
            }
            if (uiType == UIPrefab.UIComponentType.Pose)
            {
                Pose vs = new Pose();
                vs.changed += onPoseChanged;
                return vs;
            }
            if (uiType == UIPrefab.UIComponentType.Slider)
            {
                Slider vs = new Slider();
                vs.changed += onSliderChanged;
                return vs;
            }
            return null;
        }

        private void onIPChanged(string v)
        {
            string[] s = v.Split(":");
            float a = float.Parse(s[1]);
            Color color = new Color32();
            ColorUtility.TryParseHtmlString("#" + s[0], out color);
            color.a = a / 100;
            prefab.GetComponent<MeshRenderer>().material.color = color;
        }

        private void onPoseChanged(Pose v)
        {
            prefab.transform.position = new Vector3(v.x, v.y, v.z);
            prefab.transform.Rotate(new Vector3(v.rx, v.ry, v.rz));
        }

        private void onSliderChanged(float v)
        {
            prefab.transform.localScale = new Vector3(v, v, v);
        }
    }
}