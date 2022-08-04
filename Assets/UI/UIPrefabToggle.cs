using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class UIPrefabToggle : Toggle
    {
        public UIPrefab uiPrefab;
        public GameObject model;
        public VisualElement ui;

        public UIPrefabToggle(UIPrefab p) : base()
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
                    model = GameObject.Instantiate(uiPrefab.prefab);
                }
                else
                {
                    ui.style.display = DisplayStyle.None;
                    GameObject.Destroy(model);
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
            if (uiType == UIPrefab.UIComponentType.SliderX)
            {
                Slider vs = new Slider();
                vs.changed += onSliderXChanged;
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
            model.GetComponent<MeshRenderer>().material.color = color;
        }

        private void onPoseChanged(Pose v)
        {
            model.transform.position = new Vector3(v.x, v.y, v.z);
            model.transform.Rotate(new Vector3(v.rx, v.ry, v.rz));
            Debug.Log("onPoseChanged");
            Debug.Log("rotX: " + model.transform.eulerAngles.x);
        }

        private void onSliderChanged(float v)
        {
            model.transform.localScale = new Vector3(v, v, v);
        }

        private void onSliderXChanged(float v)
        {
            model.transform.position = new Vector3(v, model.transform.position.y, model.transform.position.z);
        }
    }
}