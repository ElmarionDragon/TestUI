using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class IPModel: ComponentModel
    {
        public Color color;
        public string v;

        public IPModel(): base()
        {
        }

        public void setColor(string v)
        {
            this.v = v;
            string[] s = v.Split(":");
            float a = float.Parse(s[1]);
            color = new Color32();
            ColorUtility.TryParseHtmlString("#" + s[0], out color);
            color.a = a / 100;

            notifyObservers();
        }

        override protected void Update()
        {
            if (color != null && prefabInstance != null && color != prefabInstance.GetComponent<MeshRenderer>().material.color)
            {
                color = prefabInstance.GetComponent<MeshRenderer>().material.color;
                v = ColorUtility.ToHtmlStringRGB(color) + ":" + Mathf.RoundToInt((color.a * 100));
                notifyObservers();
            }
        }
    }
}