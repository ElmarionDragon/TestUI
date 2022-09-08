using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public abstract class ComponentView: VisualElement, ComponentObserver
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

        public abstract VisualElement createUIComponent();
        public abstract void updateComponent();

        //public abstract void updateView();

        public void updateObserver()
        {

        }
    }
}