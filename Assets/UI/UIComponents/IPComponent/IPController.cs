using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class IPController: ComponentController
    {
        public IPView view;
        public IPModel model;

        public IPController(IPModel m): base()
        {
            model = m;
        }

        public void IPChanged(string v)
        {
            model.setColor(v);
        }
    }
}