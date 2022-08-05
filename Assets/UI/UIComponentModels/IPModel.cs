using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class IPModel: ComponentModel
    {
        IP ip;
        public IPModel(): base()
        {
        }

        override public VisualElement createUIComponent()
        {
            ip = new IP();
            ip.changed += onUIChanged;
            return ip;
        }

        override public void updateComponent()
        {
            onUIChanged(ip.value);
        }

        private void onUIChanged(string v)
        {
            string[] s = v.Split(":");
            float a = float.Parse(s[1]);
            Color color = new Color32();
            ColorUtility.TryParseHtmlString("#" + s[0], out color);
            color.a = a / 100;
            prefabInstance.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}