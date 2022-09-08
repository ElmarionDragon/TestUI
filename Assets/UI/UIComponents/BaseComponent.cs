using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public abstract class BaseComponent
    {
        public ComponentView view;
        public ComponentController controller;
        public ComponentModel model;

        public BaseComponent()
        {
        }

        public void updatePrefab(GameObject prefab)
        {
            view.updatePrefab(prefab);
            model.updatePrefab(prefab);
        }
    }
}