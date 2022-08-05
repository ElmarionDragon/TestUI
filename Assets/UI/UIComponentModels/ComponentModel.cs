using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public abstract class ComponentModel: VisualElement
    {
        public GameObject prefabInstance;
        public VisualElement ui;

        public ComponentModel()
        {
            ui = createUIComponent();
        }

        public void updatePrefab(GameObject m)
        {
            prefabInstance = m;
            updateComponent();
        }

        public abstract VisualElement createUIComponent();
        public abstract void updateComponent();
    }
}