using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class IPView: ComponentView
    {
        public IP ip;
        IPModel model;
        private Color color;

        public IPView(IPModel m): base()
        {
            model = m;
            model.onIPChanged += updateView;
        }

        override public VisualElement createUIComponent()
        {
            ip = new IP();
            ip.changed += onUIChanged;
            return ip;
        }

        private void onUIChanged(string v)
        {
            model.changeData(v);
        }

        override public void updateComponent()
        {
            onUIChanged(ip.value);
        }

        public void updateView(string v, Color color)
        {
            this.color = color;
            ip.update(v);
            prefabInstance.GetComponent<MeshRenderer>().material.color = color;
        }

        override public void updateUI()
        {
            if (color != null && prefabInstance != null && color != prefabInstance.GetComponent<MeshRenderer>().material.color)
            {
                color = prefabInstance.GetComponent<MeshRenderer>().material.color;
                string v = ColorUtility.ToHtmlStringRGB(color) + ":" + Mathf.RoundToInt((color.a * 100));
                model.changeData(v);
            }
        }
    }
}