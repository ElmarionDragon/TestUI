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

        public IPController(): base()
        {
            model.onIPChanged += view.updateView;
        }
    }
}