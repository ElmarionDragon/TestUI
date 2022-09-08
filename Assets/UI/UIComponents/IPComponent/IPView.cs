using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class IPView: ComponentView, ComponentObserver
    {
        IPModel model;
        IPController controller;
        public IP ip;
        
        private Color color;

        public IPView(IPController c, IPModel m): base()
        {
            model = m;
            controller = c;
            model.registerObserver(this);
        }

        override public VisualElement createUIComponent()
        {
            ip = new IP();
            ip.changed += IPChanged;
            return ip;
        }

        private void IPChanged(string v)
        {
            controller.IPChanged(v);
        }

        override public void updateComponent()
        {
            IPChanged(ip.value);
        }

        public void updateObserver()
        {
            this.color = model.color;
            string v = model.v;
            ip.update(v);
            prefabInstance.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}