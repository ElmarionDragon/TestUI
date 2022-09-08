using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public abstract class ComponentModel
    {
        private List<ComponentObserver> observers = new List<ComponentObserver>();
        public GameObject prefabInstance;

        public ComponentModel()
        {
            UpdateCaller.OnUpdate += Update;
        }

        public void registerObserver(ComponentObserver o)
        {
            observers.Add(o);
        }

        public void notifyObservers()
        {
            ComponentObserver o;
            for (int i = 0; i < observers.Count; i++)
            {
                o = observers[i];
                o.updateObserver();
            }
        }

        public void updatePrefab(GameObject m)
        {
            prefabInstance = m;
        }

        protected abstract void Update();
    }
}