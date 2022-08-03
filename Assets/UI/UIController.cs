using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class UIController : MonoBehaviour
    {
        private Button menuToggle;
        private VisualElement mainPanel;
        private VisualElement togglesPanel;

        private const string toggleUSS = "toggleTop";

        public UIPrefab[] uiPrefabs;

        private void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            menuToggle = root.Q<Button>("menuToggle");
            menuToggle.clicked += menuTogglePress;

            mainPanel = root.Q<VisualElement>("mainPanel");
            togglesPanel = root.Q<VisualElement>("togglesPanel");

            mainPanel.style.display = DisplayStyle.None;

            generateToggles();
        }

        private void generateToggles()
        {
            UIPrefabToggle toggle;
            UIPrefab uiPrefab;
            VisualElement ui;
            VisualElement scrollPanel = mainPanel.Q<VisualElement>("unity-content-container");
            for (int i = 0; i < uiPrefabs.Length; i++)
            {
                uiPrefab = uiPrefabs[i];
                toggle = new UIPrefabToggle(uiPrefab);
                toggle.AddToClassList(toggleUSS);
                toggle.name = uiPrefab.name + "Toggle";
                togglesPanel.Add(toggle);

                scrollPanel.Add(toggle.ui);
            }
        }

        public void menuTogglePress()
        {
            if (mainPanel.style.display == DisplayStyle.None) StartCoroutine(menuOpen());
            else StartCoroutine(menuClose());
        }

        private IEnumerator menuOpen()
        {
            mainPanel.style.display = DisplayStyle.Flex;
            mainPanel.style.left = -420;
            yield return null;
            mainPanel.style.left = 0;
        }

        private IEnumerator menuClose()
        {
            mainPanel.style.left = 0;
            yield return null;
            mainPanel.style.left = -420;
            yield return new WaitForSeconds(1);
            mainPanel.style.display = DisplayStyle.None;
        }

        public VisualElement getMainPanel()         {   return mainPanel;  }
        public VisualElement getTogglesPanel()         { return togglesPanel; }
    }
}