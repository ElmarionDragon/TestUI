using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class SliderModel : ComponentModel
    {
        public float size;

        public SliderModel() : base()
        {
        }
        public void setSize(float v)
        {
            this.size = v;
            notifyObservers();
        }

        override protected void Update()
        {
            if (prefabInstance != null && size != prefabInstance.transform.localScale.x)
            {
                size = prefabInstance.transform.localScale.x;
                notifyObservers();
            }
        }
    }
}