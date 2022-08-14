using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class IPModel: ComponentModel
    {
        public event Action<string, Color> onIPChanged; 
        public IPModel(): base()
        {
        }

        public void changeData(string v)
        {
            string[] s = v.Split(":");
            float a = float.Parse(s[1]);
            Color color = new Color32();
            ColorUtility.TryParseHtmlString("#" + s[0], out color);
            color.a = a / 100;

            onIPChanged(v, color);
        }
    }
}