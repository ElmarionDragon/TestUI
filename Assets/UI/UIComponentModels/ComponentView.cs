using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public abstract class ComponentView: VisualElement
    {
        public GameObject prefabInstance;
        public VisualElement ui;

        public ComponentView()
        {
            ui = createUIComponent();
        }

        public void updatePrefab(GameObject m)
        {
            prefabInstance = m;
            updateComponent();
        }

        public abstract  void updateUI();
        public abstract VisualElement createUIComponent();
        public abstract void updateComponent();
    }
}