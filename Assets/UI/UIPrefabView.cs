using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class UIPrefabView
    {
        public Toggle toggle;
        public VisualElement panelUI;
        public UIPrefabData uiPrefabData;
        public GameObject prefabInstance;
        private List<BaseComponent> components = new List<BaseComponent>();

        private const string toggleUSS = "toggleTop";
        public static bool isShowPanelUI = false;

        UIPrefabController controller;


        public UIPrefabView(UIPrefabData p)
        { 
            uiPrefabData = p;

            createToggle();
            creaetPanelUI();

            controller = new UIPrefabController(this);
        }

        private void createToggle()
        {
            toggle = new Toggle();
            toggle.label = uiPrefabData.name;
            toggle.AddToClassList(toggleUSS);
            toggle.name = uiPrefabData.name + "Toggle";
        }

        private void creaetPanelUI()
        {
            panelUI = new VisualElement();
            panelUI.AddToClassList("container");
            panelUI.name = uiPrefabData.name;

            Label title = new Label(uiPrefabData.name);
            title.AddToClassList("prefabTitle");
            panelUI.Add(title);

            BaseComponent component;
            UIPrefabData.UIComponentType uiType;
            UIPrefabData.UIComponentType[] uiComponents = uiPrefabData.uiComponents;

            for (int i = 0; i < uiComponents.Length; i++)
            {
                uiType = uiComponents[i];
                component = UIPrefabData.createUIComponent(uiType);
                panelUI.Add(component.view.ui);
                components.Add(component);
            }

            panelUI.style.display = DisplayStyle.None;
        }

        public void updatePrefab()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].updatePrefab(prefabInstance);
            }
        }

        public void updateUI()
        {
            if (!isShowPanelUI)
                return;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].updateUI();
            }
        }

        public void show()
        {
            panelUI.style.display = DisplayStyle.Flex;
            prefabInstance = GameObject.Instantiate(uiPrefabData.prefab);
            updatePrefab();
            isShowPanelUI = true;
        }


        public void hide()
        {
            isShowPanelUI = false;
            panelUI.style.display = DisplayStyle.None;
            GameObject.Destroy(prefabInstance);
        }
    }
}