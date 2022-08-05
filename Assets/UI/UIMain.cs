using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class UIMain : MonoBehaviour
    {
        private Button menuToggle;
        private VisualElement mainPanel;
        private VisualElement togglesPanel;

        public UIPrefabData[] uiPrefabs;

        private void Start()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            menuToggle = root.Q<Button>("menuToggle");
            menuToggle.clicked += menuTogglePress;

            mainPanel = root.Q<VisualElement>("mainPanel");
            togglesPanel = root.Q<VisualElement>("togglesPanel");

            mainPanel.style.display = DisplayStyle.None;

            generateUIPrefabs();
        }

        private void generateUIPrefabs()
        {
            UIPrefabData uiPrefab;
            UIPrefabView prefabView;
            
            VisualElement scrollPanel = mainPanel.Q<VisualElement>("unity-content-container");
            for (int i = 0; i < uiPrefabs.Length; i++)
            {
                uiPrefab = uiPrefabs[i];
                prefabView = new UIPrefabView(uiPrefab);
                togglesPanel.Add(prefabView.toggle);
                scrollPanel.Add(prefabView.panelUI);
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