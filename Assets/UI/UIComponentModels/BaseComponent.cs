using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public abstract class BaseComponent
    {
        public ComponentView view;

        public BaseComponent()
        {
        }

        public void updatePrefab(GameObject prefab)
        {
            view.updatePrefab(prefab);
        }

        public void updateUI()
        {
            view.updateUI();
        }
    }
}