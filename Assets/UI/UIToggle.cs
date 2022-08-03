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

        public event Action<UIPrefab, bool> changed;

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
                changed.Invoke(uiPrefab, value);
            });
        }

        public VisualElement createUI()
        {
            VisualElement container = new VisualElement();
            container.name = name;

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
            string rr = s[0].Substring(0, 2);
            string gg = s[0].Substring(2, 2);
            string bb = s[0].Substring(4, 2);
            float a = float.Parse(s[1]);
            Color color = new Color32();
            ColorUtility.TryParseHtmlString("#" + s[0], out color);
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